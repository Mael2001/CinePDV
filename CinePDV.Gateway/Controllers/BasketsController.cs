using System;
using System.Text;
using System.Threading.Tasks;
using CinePDV.Gateway.Models;
using CinePDV.Gateway.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace CinePDV.Gateway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BasketsController : ControllerBase
    {
        private readonly IShoppingBasketService _shoppingBasketService;

        public BasketsController(IShoppingBasketService shoppingBasketService)
        {
            _shoppingBasketService = shoppingBasketService;
        }

        [HttpGet("{basketId}")]
        public async Task<ActionResult<BasketDto>> GetBasketById(int basketId)
        {
            var result = await _shoppingBasketService.GetBasketByIdAsync(basketId);
            return this.Ok(result);
        }

        [HttpPost("{basketId}/BasketLines")]
        public async Task<ActionResult<BasketLineDto>> Post(int basketId, [FromBody] CreateBasketLineDto basketLineForCreation)
        {
            return await _shoppingBasketService.AddEventToBasketAsync(basketId, basketLineForCreation);
        }

        [HttpPost("{basketId}/pay")]
        public ActionResult PostPayment(Guid basketId, [FromBody] PaymentInformationDto paymentInformation)
        {
            try
            {
                paymentInformation.BasketId = basketId;
                var json = JsonConvert.SerializeObject(paymentInformation);
                var factory = new ConnectionFactory
                {
                    HostName = "localhost",
                    Port = 5672
                };

                using (var connection = factory.CreateConnection())
                {
                    using (var channel = connection.CreateModel())
                    {
                        channel.QueueDeclare("payment-queue", false, false, false, null);
                        var body = Encoding.UTF8.GetBytes(json);
                        channel.BasicPublish(string.Empty, "payment-queue", null, body);
                    }
                }

                return this.Ok(Guid.NewGuid());
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }
    }
}
