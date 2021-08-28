using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinePDV.CafeteriaCatalog.Models;

namespace CinePDV.CafeteriaCatalog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatefeteriaController : ControllerBase
    {

        private static readonly List<ProductDto> products = new List<ProductDto>
        {
            new ProductDto
            {
                CategoryId = 0,
                CategoryName = "Bebidas",
                Name = "Coca-Cola",
                Description = "Es una lata de Coca-Cola",
                Price = 250,
                ProductId = 0
            },
            new ProductDto
            {
                CategoryId = 0,
                CategoryName = "Bebidas",
                Name = "Pepsi",
                Description = "Es una lata de Pepsi",
                Price = 350,
                ProductId = 1
            },
            new ProductDto
            {
                CategoryId = 1,
                CategoryName = "Comida",
                Name = "Doritos",
                Description = "Es una bolsa de Doritos",
                Price = 150,
                ProductId = 2
            },
            new ProductDto
            {
                CategoryId = 1,
                CategoryName = "Comida",
                Name = "Hershey",
                Description = "Es un paquete Hershey",
                Price = 450,
                ProductId = 3
            },
        };
        // /events/fkasjdhf
        [HttpGet("{productId}")]
        public ActionResult<ProductDto> GetById(int productId)
        {
            return this.Ok(products.FirstOrDefault(x => x.ProductId == productId));
        }

        //events?categoryId=fajsdflka
        [HttpGet]
        public ActionResult<IEnumerable<ProductDto>> Get([FromQuery] int categoryId)
        {
            return this.Ok(products.Where(x => x.CategoryId == categoryId));
        }
    }
}
