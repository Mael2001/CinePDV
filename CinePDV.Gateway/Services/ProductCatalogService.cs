using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CinePDV.Gateway.Models;
using Newtonsoft.Json;

namespace CinePDV.Gateway.Services
{
    public class ProductCatalogService : IProductCatalogService
    {
        private readonly HttpClient _httpClient;

        public ProductCatalogService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ProductCategoryDto>> GetCategoriesAsync()
        {
            var categories = await _httpClient.GetStringAsync("Categories");
            return JsonConvert.DeserializeObject<IEnumerable<ProductCategoryDto>>(categories);
        }

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var eventData = await _httpClient.GetStringAsync($"Events/{id}");
            return JsonConvert.DeserializeObject<ProductDto>(eventData);
        }

        public async Task<IEnumerable<ProductDto>> GetProductsByCategoryAsync(int categoryId)
        {
            var eventData = await _httpClient.GetStringAsync($"Events?categoryId={categoryId}");
            return JsonConvert.DeserializeObject<IEnumerable<ProductDto>>(eventData);
        }
    }
}
