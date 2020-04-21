using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC2Labb2.Models;
using MVC2Labb2.Repositories;
using MVC2Labb2.Services;
using MVC2Labb2.ViewModels;

namespace MVC2Labb2.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieListBuilder movieListBuilder;
        private readonly IMovieRepository movieRepository;
        private readonly IMapper mapper;

        public MovieController(IMovieListBuilder movieListBuilder, IMovieRepository movieRepository, IMapper mapper )
        {
            this.movieListBuilder = movieListBuilder;
            this.movieRepository = movieRepository;
            this.mapper = mapper;
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

        [HttpGet]
        public IActionResult MovieDetails(int Id)
        {
            var movie = movieRepository.GetMovie(Id);
            var model = mapper.Map<MovieDetailsViewModel>(movie);
            return View(model);
        }
    }
}