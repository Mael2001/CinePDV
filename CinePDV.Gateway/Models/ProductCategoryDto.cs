using System;
using System.Collections.Generic;

namespace CinePDV.Gateway.Models
{
    public class ProductCategoryDto
    {
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public IEnumerable<ProductDto> Products { get; set; }
    }
}
