using Microsoft.Extensions.Caching.Memory;
using MVC2Labb2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC2Labb2.Repositories
{
    public class CacheMovieRepository : IMovieRepository
    {
        private readonly IMemoryCache cache;
        private readonly IMovieRepository movieRepository;

        public CacheMovieRepository(IMemoryCache cache, IMovieRepository movieRepository )
        {
            this.movieRepository = movieRepository;
            this.cache = cache;
        }
        public IQueryable<Film> GetAll()
        {
            return movieRepository.GetAll();
        }

        public Film GetMovie(int id)
        {
            var key = "movie" + id;

            var cachedMovie = cache.GetOrCreate(key, movie =>
            {
                movie.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(60);
                return movieRepository.GetMovie(id);
            });

           return cachedMovie;
        }

        public int GetPageAmount(int amountMoviesResult)
        {
            return movieRepository.GetPageAmount(amountMoviesResult);
        }
    }
}
