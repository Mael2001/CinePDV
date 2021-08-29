using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CinePDV.ShoppingBasket.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CinePDV.ShoppingBasket.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BasketLinesController : ControllerBase
    {
        Semaphore semaphoreObject = new Semaphore(initialCount: 1, maximumCount: 1, name: "ProductPricing");

        [HttpGet("/ShoppingBaskets/{basketId}/BasketLines")]
        public ActionResult<IEnumerable<BasketLineDto>> Get(int basketId)
        {
            var basket = Database.Baskets.FirstOrDefault(x => x.BasketId == basketId);
            if (basket == null)
            {
                return this.NotFound();
            }

            var basketLines = Database.BasketLines.Where(x => x.Basket == basketId);
            return this.Ok(basketLines);
        }

        [HttpPost("/ShoppingBaskets/{basketId}/BasketLines")]
        public async Task<ActionResult<BasketLineDto>> Post(int basketId, [FromBody] CreateBasketLineDto basketLineForCreation)
        {
            var basket = Database.Baskets.FirstOrDefault(x => x.BasketId == basketId);
            if (basket == null)
            {
                return this.NotFound("No existe el carrito!");
            }

            MovieDto movieData = null;
            if (Database.Movies.All(x => x.MovieId != basketLineForCreation.MovieId))
            {
                using (var httpClient = new HttpClient())
                {
                    var response =
                        await httpClient.GetStringAsync(
                            $"http://localhost:33977/events/{basketLineForCreation.MovieId}");
                    movieData = JsonConvert.DeserializeObject<MovieDto>(response);
                    Database.Movies.Add(movieData);
                }
            }

            List<ProductDto> productList = new List<ProductDto>();
            Parallel.ForEach(basketLineForCreation.ProductId, (id) =>
            {
                ProductDto productData = null;

                Parallel.ForEach(Database.Products, async (product) =>
                {
                    if (product.All(x => x.ProductId != id))
                    {
                        using (var httpClient = new HttpClient())
                        {
                            var response =
                                await httpClient.GetStringAsync(
                                    $"http://localhost:33977/events/{id}");
                            productData = JsonConvert.DeserializeObject<ProductDto>(response);
                            productList.Add(productData);
                        }
                    }
                });
            });
            Database.Products.Add(productList);
            if (movieData == null || productList.Count == 0)
            {
                return this.Ok("No existe la pelicula o productos pedido");
            }

            decimal completePrice = 0;

            Parallel.ForEach(productList, (product) =>
            {
                semaphoreObject.WaitOne();
                completePrice += product.Price;
                semaphoreObject.Release();
            });

            var basketLine = new BasketLineDto
            {
                MovieId = basketLineForCreation.MovieId,
                MoviePrice = movieData.Price,
                ProductTotalPrice = completePrice,
                Basket = basketLineForCreation.BasketId,
                TicketQuantity = basketLineForCreation.TicketQuantity,
                BasketLineId = new int(),
                Movie = basketLineForCreation.Movie,
                Product = basketLineForCreation.Product
            };
            Database.BasketLines.Add(basketLine);

            return this.Ok(basketLine);
        }
    }
}
