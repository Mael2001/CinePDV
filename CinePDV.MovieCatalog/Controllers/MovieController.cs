using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinePDV.MovieCatalog.Models;

namespace CinePDV.MovieCatalog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {

        private static readonly List<MovieDto> movies = new List<MovieDto>
        {
            new MovieDto
            {
                CategoryId = 0,
                CategoryName = "Horror",
                Name = "Silent-Hill",
                Description = "Horror Movie",
                ExpositionTime = DateTime.Now.AddDays(1),
                MovieId = 0
            },
            new MovieDto
            {
                CategoryId = 1,
                CategoryName = "Thriller",
                Name = "SongBird",
                Description = "Thriller Movie",
                ExpositionTime = DateTime.Now.AddDays(2),
                MovieId = 1
            },
            new MovieDto
            {
                CategoryId = 2,
                CategoryName = "Action",
                Name = "Endgame",
                Description = "Action Movie",
                ExpositionTime = DateTime.Now.AddDays(3),
                MovieId = 2
            },
            new MovieDto
            {
                CategoryId = 3,
                CategoryName = "Comedy",
                Name = "Willy-Wonka",
                Description = "Comedy Movie",
                ExpositionTime = DateTime.Now.AddDays(4),
                MovieId = 3
            },
            new MovieDto
            {
                CategoryId = 4,
                CategoryName = "Mystery",
                Name = "Forgotten",
                Description = "Es un paquete Hershey",
                ExpositionTime = DateTime.Now.AddDays(5),
                MovieId = 4
            },
            new MovieDto
            {
                CategoryId = 5,
                CategoryName = "Romance",
                Name = "Kissing Booth",
                Description = "Romance Movie",
                ExpositionTime = DateTime.Now.AddDays(6),
                MovieId = 5
            },
        };
        // /events/fkasjdhf
        [HttpGet("{movieId}")]
        public ActionResult<MovieDto> GetById(int movieId)
        {
            return this.Ok(movies.FirstOrDefault(x => x.MovieId == movieId));
        }

        //events?categoryId=fajsdflka
        [HttpGet]
        public ActionResult<IEnumerable<MovieDto>> Get([FromQuery] int categoryId)
        {
            return this.Ok(movies.Where(x => x.CategoryId == categoryId));
        }
    }
}
