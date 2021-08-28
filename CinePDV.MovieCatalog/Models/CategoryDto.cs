using System.Collections.Generic;

namespace CinePDV.MovieCatalog.Models
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public IEnumerable<MovieDto> Movies { get; set; }
    }
}