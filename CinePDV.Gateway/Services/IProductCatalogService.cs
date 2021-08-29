using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CinePDV.Gateway.Models;

namespace CinePDV.Gateway.Services
{
    public interface IProductCatalogService
    {
        Task<IEnumerable<ProductCategoryDto>> GetCategoriesAsync();

        Task<ProductDto> GetProductByIdAsync(int id);

        Task<IEnumerable<ProductDto>> GetProductsByCategoryAsync(int categoryId);
    }
}
