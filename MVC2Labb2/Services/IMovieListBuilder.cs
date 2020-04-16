using MVC2Labb2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC2Labb2.Services
{
    public interface IMovieListBuilder
    {
        MovieListBuilder InitialSettings(string sortColumn, string sortOrder, int currentPage, int moviesInPage);
        MovieListBuilder ThenGetAllMovies();
        MovieListBuilder ThenSort();
        MovieListBuilder ThenFilterMoviesToPage();
        MovieViewModel BuildMovieViewModel();
    }
}
