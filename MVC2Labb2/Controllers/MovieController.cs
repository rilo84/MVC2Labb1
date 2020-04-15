using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC2Labb2.Repositories;
using MVC2Labb2.ViewModels;

namespace MVC2Labb2.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepository movieRepository;

        public MovieController(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        [HttpGet]
        public async Task<IActionResult> MovieList(string sortColumn, string sortOrder)
        {
            var model = new MovieViewModel ();

            var movies = movieRepository.GetAll()
                .Select(m => new MovieViewModel.Movie { Title = m.Title, Release = m.ReleaseYear });
           
            switch (sortColumn, sortOrder)
            {
                case ("title", "asc"):
                    {
                        movies = movies.OrderBy(m => m.Title);
                        break;
                    }

                case ("title", "desc"):
                    {
                        movies = movies.OrderByDescending(m => m.Title);
                        break;
                    }
                case ("date", "asc"):
                    {
                        movies = movies.OrderBy(m => m.Release);
                        break;
                    }

                case ("date", "desc"):
                    {
                        movies = movies.OrderByDescending(m => m.Release);
                        break;
                    }
                default:
                    movies = movies.OrderBy(m => m.Title);
                    break;
            }

            model.SortOrder = (sortOrder == "asc" || sortOrder == null) ? "desc" : "asc";
            model.Movies = await movies.ToListAsync();

            return View(model);
        }
    }
}