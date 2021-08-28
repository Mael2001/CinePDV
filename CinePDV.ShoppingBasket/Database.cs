using System.Collections.Generic;
using CinePDV.ShoppingBasket.Models;

namespace CinePDV.ShoppingBasket
{
    public static class Database
    {
        public static readonly List<BasketDto> Baskets = new List<BasketDto>
        {
            new BasketDto
            {
                BasketId = -1,
                NumberOfItems = 0,
                UserId = -1
            }
        };

        public static readonly List<List<ProductDto>> Products = new List<List<ProductDto>>();
        public static readonly List<MovieDto> Movies = new List<MovieDto>();

        public static readonly List<BasketLineDto> BasketLines = new List<BasketLineDto>();
    }
}
