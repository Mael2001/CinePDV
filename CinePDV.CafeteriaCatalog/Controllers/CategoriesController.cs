using System;
using System.Collections.Generic;
using System.Linq;
using CinePDV.CafeteriaCatalog.Models;
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
                Name = "Bebidas"
            },
            new CategoryDto
            {
                CategoryId = 1,
                Name = "Comida"
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