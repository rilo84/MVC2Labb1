using MVC2Labb2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC2Labb2.Services
{
    public class SortMovies : ISortMovies
    {
        public IQueryable<MovieViewModel.Movie> Sort(IQueryable<MovieViewModel.Movie> movies, string sortColumn, string sortOrder)
        {
            switch (sortColumn, sortOrder)
            {
                case ("title", "asc"):
                    {
                        return movies.OrderBy(m => m.Title);
                    }

                case ("title", "desc"):
                    {
                        return movies.OrderByDescending(m => m.Title);
                    }
                case ("date", "asc"):
                    {
                        return movies.OrderBy(m => m.Release);
                    }

                case ("date", "desc"):
                    {
                        return movies.OrderByDescending(m => m.Release);
                    }
                case ("rate", "asc"):
                    {
                        return movies.OrderBy(m => m.RentalRate);
                    }

                case ("rate", "desc"):
                    {
                        return movies.OrderByDescending(m => m.RentalRate);
                    }
                default:
                    return movies.OrderBy(m => m.Title);
            }
        }
    }
}
