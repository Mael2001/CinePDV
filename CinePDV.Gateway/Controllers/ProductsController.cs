using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CinePDV.Gateway.Models;
using CinePDV.Gateway.Services;
using Microsoft.AspNetCore.Mvc;

namespace CinePDV.Gateway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductCatalogService _productCatalogService;

        public ProductsController(IProductCatalogService productCatalogService)
        {
            _productCatalogService = productCatalogService;
        }

        [HttpGet("categories")]
        public async Task<ActionResult<ProductCategoryDto>> GetCategories()
        {
            var result = await _productCatalogService.GetCategoriesAsync();
            return this.Ok(result);
        }

        [HttpGet("events/{id}")]
        public async Task<ActionResult<ProductCategoryDto>> GetEventById(int id)
        {
            var result = await _productCatalogService.GetProductByIdAsync(id);
            return this.Ok(result);
        }

        [HttpGet("events")]
        public async Task<ActionResult<IEnumerable<ProductCategoryDto>>> GetEventsByCategory([FromQuery]int categoryId)
        {
            var result = await _productCatalogService.GetProductsByCategoryAsync(categoryId);
            return this.Ok(result);
        }
    }
}
