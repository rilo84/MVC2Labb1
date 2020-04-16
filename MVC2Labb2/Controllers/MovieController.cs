using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC2Labb2.Repositories;
using MVC2Labb2.Services;
using MVC2Labb2.ViewModels;

namespace MVC2Labb2.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepository movieRepository;
        private readonly ISortMovies sortMovies;

        public MovieController(IMovieRepository movieRepository, ISortMovies sortMovies)
        {
            this.movieRepository = movieRepository;
            this.sortMovies = sortMovies;
        }

        [HttpGet]
        public async Task<IActionResult> MovieList(string sortColumn = "title", string sortOrder = "asc", int page = 1, int items = 30)
        {
            var model = new MovieViewModel (sortColumn,sortOrder,page,items);
            model.Pages = movieRepository.GetPageAmount(model.MoviesInPage);

            var movies = movieRepository.GetAll()
                .Select(m => new MovieViewModel.Movie { Title = m.Title, Release = m.ReleaseYear, RentalRate = m.RentalRate });

            movies = sortMovies.Sort(movies, sortColumn, sortOrder);
            model.Movies = await movies.Skip((page - 1) * model.MoviesInPage).Take(model.MoviesInPage).ToListAsync();

            return View(model);
        }
    }
}