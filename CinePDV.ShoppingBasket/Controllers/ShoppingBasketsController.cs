using System.Linq;
using CinePDV.ShoppingBasket.Models;
using Microsoft.AspNetCore.Mvc;

namespace CinePDV.ShoppingBasket.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShoppingBasketsController : ControllerBase
    {

        [HttpGet("{basketId}")]
        public ActionResult<BasketDto> Get(int basketId)
        {
            var basket = Database.Baskets.FirstOrDefault(x => x.BasketId == basketId);
            if (basket == null)
            {
                return this.NotFound($"No se encontró un basket con id: {basketId}");
            }

            return this.Ok(basket);
        }

        [HttpPost]
        public ActionResult<BasketDto> Post([FromBody] CreateBasketDto basketForCreation)
        {
            var basket = new BasketDto
            {
                UserId = basketForCreation.UserId,
                BasketId = new int()
            };

            Database.Baskets.Add(basket);
            return this.Ok(basket);
        }
    }
}
