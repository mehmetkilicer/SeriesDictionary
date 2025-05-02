using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SeriesDictionary.Dto.RegisterDto;

namespace SeriesDictionary.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public RegisterController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult CreateAppUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppUser(CreateRegisterDto createRegisterDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createRegisterDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7257/api/Registers", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Login");
            }

            var errorMessage = await responseMessage.Content.ReadAsStringAsync();
            Console.WriteLine("Hata Mesajı: " + errorMessage);
            ModelState.AddModelError("", "Kayıt işlemi başarısız: " + errorMessage);

            return View();
        }

    }
}

