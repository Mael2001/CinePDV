using System;
using System.Collections.Generic;
using System.Linq;
using CinePDV.MovieCatalog.Models;
using Microsoft.AspNetCore.Mvc;

namespace CinePDV.CafeteriaCatalog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {

        private static readonly List<CategoryDto> Categories = new List<CategoryDto>
        {
            new CategoryDto
            {
                CategoryId = 0,
                Name = "Horror"
            },
            new CategoryDto
            {
                CategoryId = 1,
                Name = "Thriller"
            },
            new CategoryDto
            {
                CategoryId = 2,
                Name = "Action"
            },
            new CategoryDto
            {
                CategoryId = 3,
                Name = "Comedy"
            },
            new CategoryDto
            {
                CategoryId = 4,
                Name = "Mystery"
            },
            new CategoryDto
            {
                CategoryId = 5,
                Name = "Romance"
            },
        };

        [HttpGet]
        public ActionResult<IEnumerable<CategoryDto>> Get()
        {
            return this.Ok(Categories);
        }

        [HttpGet("{categoryId}")]
        public ActionResult<IEnumerable<CategoryDto>> Get(int categoryId)
        {
            return this.Ok(Categories.FirstOrDefault(x => x.CategoryId == categoryId));
        }
        
    }
}