﻿using System;

namespace CinePDV.Gateway.Models
{
    public class ProductDto
    {

        public int ProductId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
        public ProductCategoryDto Category { get; set; }
    }
}
