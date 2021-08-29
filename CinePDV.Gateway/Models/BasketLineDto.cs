using System;
using System.Collections.Generic;

namespace CinePDV.Gateway.Models
{
    public class BasketLineDto
    {
        public int BasketLineId { get; set; }

        public int Basket { get; set; }

        public int MovieId { get; set; }
        public List<int> ProductId { get; set; }

        public decimal MoviePrice { get; set; }
        public decimal ProductTotalPrice { get; set; }

        public int TicketQuantity { get; set; }

        public List<ProductDto> Product { get; set; }
        public MovieDto Movie { get; set; }
    }
}
