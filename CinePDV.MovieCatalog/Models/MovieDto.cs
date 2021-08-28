﻿using System;

namespace CinePDV.MovieCatalog.Models
{
    public class MovieDto
    {
        public int MovieId { get; set; }

        public string Name { get; set; }

        public DateTime ExpositionTime { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
        public decimal Price { get; set; }
        public CategoryDto Category { get; set; }
    }
}