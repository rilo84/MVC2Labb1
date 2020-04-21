using MVC2Labb2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MVC2Labb2.Repositories
{
    public class MovieRepository: IMovieRepository
    {
        private readonly sakilaContext context;

        public MovieRepository(sakilaContext context)
        {
            this.context = context;
        }

        public IQueryable<Film> GetAll()
        {
            return context.Film;
        }

        public Film GetMovie(int id)
        {
            return context.Film.FirstOrDefault(m => m.FilmId == id);
        }

        public int GetPageAmount(int amountMoviesResult)
        {
            decimal amountMovies = context.Film.Count();
            return (int)Math.Ceiling(amountMovies / amountMoviesResult);
        }
    }
}
