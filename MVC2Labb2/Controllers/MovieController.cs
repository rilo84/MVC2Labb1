using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult MovieList(string sortColumn, string sortOrder)
        {
            var model = new MovieViewModel();
            var (col, order) = (sortColumn, sortOrder);
            var movies = movieRepository.GetAll()
                .Select(m => new MovieViewModel.Movie { Title = m.Title, Release = m.ReleaseYear });
           
            switch ((col,order))
            {
                case ("title", "asc"):
                    {
                        model.Movies = movies.OrderBy(m => m.Title).ToList();
                        model.SortOrder = "desc";
                        return View(model);
                    }

                case ("title", "desc"):
                    {
                        model.Movies = movies.OrderByDescending(m => m.Title).ToList();
                        model.SortOrder = "asc";
                        return View(model);
                    }
                case ("date", "asc"):
                    {
                        model.Movies = movies.OrderBy(m => m.Release).ToList();
                        model.SortOrder = "desc";
                        return View(model);
                    }

                case ("date", "desc"):
                    {
                        model.Movies = movies.OrderByDescending(m => m.Release).ToList();
                        model.SortOrder = "asc";
                        return View(model);
                    }
                default:
                    model.Movies = movies.OrderBy(m => m.Title).ToList();
                    model.SortOrder = "desc";
                    return View(model);
            }
        }
    }
}