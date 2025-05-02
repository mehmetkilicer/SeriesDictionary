using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SeriesDictionary.Application.Features.Mediator.Commands.AppUserCommands;
using SeriesDictionary.Application.Features.Mediator.Results.AppUserResults;

namespace SeriesDictionary.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/UserManagement")]
    public class UserManagementController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public UserManagementController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7257/api/UserApi/userlist");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetUserQueryResult>>(jsonData);
                return View(values);
            }
            return View();
        }
        [Route("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7257/api/UserApi/userdelete?id={id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "UserManagement", new { area = "Admin" });
            }

            // Eğer silme işlemi başarısızsa, hata sayfasına yönlendirebilirsiniz veya bir hata mesajı döndürebilirsiniz
            return RedirectToAction("Error", "Home", new { area = "Admin" }); // Hata durumunda alternatif yönlendirme
        }


        [HttpGet]
        [Route("UpdateUser/{id}")]
        public async Task<IActionResult> UpdateUser(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7257/api/UserApi/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetUserByIdQueryResult>(jsonData);
                return View(values); // Kullanıcı verilerini View'a gönder
            }

            // Hata durumunda boş bir model döndür
            return View(new GetUserByIdQueryResult());
        }
        [HttpPost]
        [Route("UpdateUser/{id}")]
        public async Task<IActionResult> UpdateUser(UpdateAppUserCommand command)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(command);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7257/api/UserApi/userupdate/", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "UserManagement", new { area = "Admin" });
            }

            // Hata durumunda modeli tekrar yükle
            var getResponse = await client.GetAsync($"https://localhost:7257/api/UserApi/{command.AppUserId}");
            if (getResponse.IsSuccessStatusCode)
            {
                var jsonGetData = await getResponse.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetUserByIdQueryResult>(jsonGetData);
                if (values != null)
                {
                    TempData["Error"] = "Güncelleme başarısız oldu.";
                    return View(values);
                }
            }

            TempData["Error"] = "Kullanıcı verileri alınamadı.";
            return View(new GetUserByIdQueryResult());
        }


    }
}
