using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CinePDV.Gateway.Models;

namespace CinePDV.Gateway.Services
{
    public interface IMovieCatalogService
    {

        Task<IEnumerable<MovieCategoryDto>> GetCategoriesAsync();

        Task<MovieDto> GetMovieByIdAsync(int id);

        Task<IEnumerable<MovieDto>> GetMoviesByCategoryAsync(int categoryId);
    }
}