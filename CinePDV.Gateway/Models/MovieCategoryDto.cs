using System.Collections.Generic;

namespace CinePDV.Gateway.Models
{
    public class MovieCategoryDto
    {
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public IEnumerable<MovieDto> Movies { get; set; }
    }
}