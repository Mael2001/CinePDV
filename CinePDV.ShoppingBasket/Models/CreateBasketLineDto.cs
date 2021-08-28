using System.Collections.Generic;

namespace CinePDV.ShoppingBasket.Models
{
    public class CreateBasketLineDto
    {
        public int BasketId { get; set; }

        public int MovieId { get; set; }
        public List<int> ProductId { get; set; }

        public int TicketQuantity { get; set; }

        public List<ProductDto> Product { get; set; }
        public MovieDto Movie { get; set; }
    }
}
