using Microsoft.EntityFrameworkCore;
using MVC2Labb2.Repositories;
using MVC2Labb2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static MVC2Labb2.ViewModels.MovieViewModel;

namespace MVC2Labb2.Services
{
    public class MovieListBuilder:IMovieListBuilder
    {
        private readonly IMovieRepository movieRepository;

        public MovieListBuilder(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        private string SortColumn { get; set; }
        private string SortOrder { get; set; }
        private int MoviesInPage { get; set; }
        private int Pages { get; set; }
        private int CurrentPage { get; set; }
        private IQueryable<Movie> Movies { get; set; }

        public MovieListBuilder InitialSettings(string sortColumn, string sortOrder, int currentPage, int moviesInPage)
        {
            SortColumn = sortColumn;
            SortOrder = sortOrder;
            CurrentPage = currentPage;
            MoviesInPage = moviesInPage;
            Pages = movieRepository.GetPageAmount(MoviesInPage);
            return this;
        }
        
        public MovieListBuilder ThenGetAllMovies()
        {
            Movies = movieRepository.GetAll()
                .Select(m => new Movie { Title = m.Title, Release = m.ReleaseYear, RentalRate = m.RentalRate });
            return this;
        }

        public MovieListBuilder ThenSort()
        {
            switch (SortColumn, SortOrder)
            {
                case ("title", "asc"):
                    {
                        Movies = Movies.OrderBy(m => m.Title);
                        break;
                    }

                case ("title", "desc"):
                    {
                        Movies = Movies.OrderByDescending(m => m.Title);
                        break;
                    }
                case ("date", "asc"):
                    {
                        Movies = Movies.OrderBy(m => m.Release);
                        break;
                    }

                case ("date", "desc"):
                    {
                        Movies = Movies.OrderByDescending(m => m.Release);
                        break;
                    }
                case ("rate", "asc"):
                    {
                        Movies = Movies.OrderBy(m => m.RentalRate);
                        break;
                    }

                case ("rate", "desc"):
                    {
                        Movies = Movies.OrderByDescending(m => m.RentalRate);
                        break;
                    }
                default:
                    Movies = Movies.OrderBy(m => m.Title);
                    break;
            }
            return this;
        }

        public MovieListBuilder ThenFilterMoviesToPage()
        {
            Movies = Movies.Skip((CurrentPage - 1) * MoviesInPage).Take(MoviesInPage);
            return this;
        }

        public MovieViewModel BuildMovieViewModel()
        {
            return new MovieViewModel(SortColumn, SortOrder, CurrentPage, MoviesInPage, Pages, Movies.ToList());
        }
    }
}
