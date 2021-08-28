using System.Collections.Generic;

namespace CinePDV.CafeteriaCatalog.Models
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public IEnumerable<ProductDto> Products { get; set; }

    }
}