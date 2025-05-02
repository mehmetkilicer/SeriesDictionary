using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SeriesDictionary.Application.Features.Mediator.Commands.ShowCommands;
using SeriesDictionary.Application.Features.Mediator.Results.AppUserResults;
using SeriesDictionary.Application.Features.Mediator.Results.EpisodeResults;
using SeriesDictionary.Application.Features.Mediator.Results.ListShowResults;
using SeriesDictionary.Application.Features.Mediator.Results.ShowResults;
using SeriesDictionary.Dto.SeriesDto;

namespace SeriesDictionary.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminShow")]
    public class AdminShowController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminShowController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7257/api/Show/seriesandmovies");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetSeriesAndMoviesQueryResult>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        [Route("CreateShow")]
        public IActionResult CreateShow()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateShow")]
        public async Task<IActionResult> CreateShow(CreateShowCommand createShowCommand)
        {
            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine($"ModelState Hatası: {error.ErrorMessage}");
                }
                return View(createShowCommand);
            }

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createShowCommand, new JsonSerializerSettings
            {
                // PascalCase'i koru
                ContractResolver = new DefaultContractResolver()
            });
            Console.WriteLine($"Gönderilen JSON: {jsonData}"); // JSON'u logla
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7257/api/Show/create", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminShow", new { area = "Admin" });
            }
            else
            {
                var errorContent = await responseMessage.Content.ReadAsStringAsync();
                TempData["Error"] = $"API hatası: {errorContent}";
                Console.WriteLine($"API hatası: {errorContent}");
                return View(createShowCommand);
            }
        }
        [Route("RemoveShow/{id}")]
        public async Task<IActionResult> RemoveShow(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7257/api/Show/delete?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminShow", new { area = "Admin" });
            }
            return View();
        }
        [HttpGet]
        [Route("UpdateShow/{id}")]
        public async Task<IActionResult> UpdateShow(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7257/api/Show/{id}"); // 🟢 DOĞRU URL
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateShowCommand>(jsonData);
                return View(values);
            }
            return View(); // hata durumu
        }



        [HttpPost]
        [Route("UpdateShow/{id}")]
        public async Task<IActionResult> UpdateShow(UpdateShowCommand updateShowCommand)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateShowCommand);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7257/api/Show/update", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminShow", new { area = "Admin" });
            }
            return View();
        }
    }
}
