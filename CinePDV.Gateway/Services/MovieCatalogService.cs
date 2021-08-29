using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CinePDV.Gateway.Models;
using Newtonsoft.Json;

namespace CinePDV.Gateway.Services
{
    public class MovieCatalogService : IMovieCatalogService
    {
        private readonly HttpClient _httpClient;

        public MovieCatalogService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<MovieCategoryDto>> GetCategoriesAsync()
        {
            var categories = await _httpClient.GetStringAsync("Categories");
            return JsonConvert.DeserializeObject<IEnumerable<MovieCategoryDto>>(categories);
        }

        public async Task<MovieDto> GetMovieByIdAsync(int id)
        {
            var eventData = await _httpClient.GetStringAsync($"Events/{id}");
            return JsonConvert.DeserializeObject<MovieDto>(eventData);
        }

        public async Task<IEnumerable<MovieDto>> GetMoviesByCategoryAsync(int categoryId)
        {
            var eventData = await _httpClient.GetStringAsync($"Events?categoryId={categoryId}");
            return JsonConvert.DeserializeObject<IEnumerable<MovieDto>>(eventData);
        }
    }
}