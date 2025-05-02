using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SeriesDictionary.Dto.MovieDto;
using SeriesDictionary.Dto.MovieDto.SeriesDictionary.Application.DTOs;
using SeriesDictionary.Dto.WordDto;
using SeriesDictionary.Persistence.Context;
using SeriesDictionary.WebUI.Models;

namespace SeriesDictionary.WebUI.Controllers
{
    public class DefaultController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int? episodeId, int? difficultyId, int page = 1, int pageSize = 10)
        {
            // API URL'si
            var apiUrl = $"https://localhost:7257/api/WordEpisode/byEpisodeAndDifficulty?episodeId={episodeId}&difficultyId={difficultyId}";

            // HTTP client oluşturuluyor
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync(apiUrl);

            if (responseMessage.IsSuccessStatusCode)
            {
                // API'den gelen JSON verisini deserialize ediyoruz
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var words = JsonConvert.DeserializeObject<List<WordsByEpisodeAndDifficultyDto>>(jsonData);

                // Sayfalama işlemi
                var pagedWords = words.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                var totalItems = words.Count;

                // PagedList modelini oluşturuyoruz
                var model = new PagedList<WordsByEpisodeAndDifficultyDto>
                {
                    Items = pagedWords,
                    CurrentPage = page,
                    PageSize = pageSize,
                    TotalItems = totalItems
                };

                // ViewData ile parametreleri gönderiyoruz
                ViewData["EpisodeId"] = episodeId;
                ViewData["DifficultyId"] = difficultyId;
                ViewData["Page"] = page;
                ViewData["PageSize"] = pageSize;

                // Modeli View'a gönderiyoruz
                return View(model);
            }

            // Veriler alınamadıysa boş bir model gönderiyoruz
            return View();
        }


    }
}
