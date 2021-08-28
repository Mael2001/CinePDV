using System;

namespace CinePDV.ShoppingBasket.Models
{
    public class ProductDto
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
    }
    public class MovieDto
    {
        public int MovieId { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public decimal Price { get; set; }
    }
}
