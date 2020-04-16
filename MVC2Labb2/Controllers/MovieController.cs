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
        private readonly IMovieListBuilder movieListBuilder;

        public MovieController(IMovieListBuilder movieListBuilder )
        {
            this.movieListBuilder = movieListBuilder;
        }

        [HttpGet]
        public IActionResult MovieList(string sortColumn = "title", string sortOrder = "asc", int page = 1, int items = 30)
        {
            var model = movieListBuilder
                .InitialSettings(sortColumn, sortOrder, page, items)
                .ThenGetAllMovies()
                .ThenSort()
                .ThenFilterMoviesToPage()
                .BuildMovieViewModel();

            return View(model);
        }
    }
}