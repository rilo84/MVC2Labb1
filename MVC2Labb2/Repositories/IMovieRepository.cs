using MVC2Labb2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC2Labb2.Repositories
{
    public interface IMovieRepository
    {
        int GetPageAmount(int amountMoviesResult);
        IQueryable<Film> GetAll();
    }
}
