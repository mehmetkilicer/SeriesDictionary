﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SeriesDictionary.Application.Features.Mediator.Results.EpisodeResults;
using SeriesDictionary.Application.Features.Mediator.Results.ListShowResults;
using SeriesDictionary.Dto.MovieDto;
using SeriesDictionary.Dto.MovieDto.SeriesDictionary.Application.DTOs;


namespace SeriesDictionary.WebUI.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MoviesController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7257/api/Show/movies");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetMovieQueryResult>>(jsonData);
                return View(values);
            }
            return View();
        }


        public async Task<IActionResult> Details(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7257/api/Show/details/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var showDetail = JsonConvert.DeserializeObject<ShowDetailsViewModel>(jsonData, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore // Döngüsel referansları ihmal et
                });

                ViewData["EpisodeId"] = id; // EpisodeId'yi ViewData ile gönder
                return View(showDetail);
            }

            return View(new ShowDetailsViewModel()); // Boş bir model döndür
        }


    }
}
