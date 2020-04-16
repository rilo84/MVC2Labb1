using MVC2Labb2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC2Labb2.Services
{
    public interface ISortMovies
    {
        IQueryable<MovieViewModel.Movie> Sort(IQueryable<MovieViewModel.Movie> movies, string sortColumn, string sortOrder);
    }
}
