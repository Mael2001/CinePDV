using System;
using System.Threading.Tasks;
using CinePDV.Gateway.Models;

namespace CinePDV.Gateway.Services
{
    public interface IShoppingBasketService
    {
        Task<BasketDto> GetBasketByIdAsync(int id);

        Task<BasketLineDto> AddEventToBasketAsync(int basketId, CreateBasketLineDto lineToAdd);
    }
}
