using System;
using System.Collections.Generic;

namespace CinePDV.Gateway.Models
{
    public class BasketDto
    {
        public int BasketId { get; set; }

        public int UserId { get; set; }

        public int NumberOfItems { get; set; }

        public IEnumerable<BasketLineDto> BasketLines { get; set; }
    }
}
