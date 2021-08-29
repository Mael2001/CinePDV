using System.Collections.Generic;
using System.Threading.Tasks;
using CinePDV.Gateway.Models;
using CinePDV.Gateway.Services;
using Microsoft.AspNetCore.Mvc;

namespace CinePDV.Gateway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieTicketController : ControllerBase
    {
        private readonly IMovieCatalogService _movieCatalogService;

        public MovieTicketController(IMovieCatalogService movieCatalogService)
        {
            _movieCatalogService = movieCatalogService;
        }

        [HttpGet("categories")]
        public async Task<ActionResult<ProductCategoryDto>> GetCategories()
        {
            var result = await _movieCatalogService.GetCategoriesAsync();
            return this.Ok(result);
        }

        [HttpGet("events/{id}")]
        public async Task<ActionResult<ProductCategoryDto>> GetEventById(int id)
        {
            var result = await _movieCatalogService.GetMovieByIdAsync(id);
            return this.Ok(result);
        }

        [HttpGet("events")]
        public async Task<ActionResult<IEnumerable<ProductCategoryDto>>> GetEventsByCategory([FromQuery] int categoryId)
        {
            var result = await _movieCatalogService.GetMoviesByCategoryAsync(categoryId);
            return this.Ok(result);
        }
    }
}