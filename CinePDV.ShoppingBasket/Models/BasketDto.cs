using System;

namespace CinePDV.ShoppingBasket.Models
{
    public class BasketDto
    {
        public int BasketId { get; set; }

        public int UserId { get; set; }

        public int NumberOfItems { get; set; }
    }
}
