using AutoMapper;
using MVC2Labb2.Models;
using MVC2Labb2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC2Labb2.Middleware
{
    public class MoviesProfile:Profile
    {
        public MoviesProfile()
        {
            CreateMap<Film,MovieDetailsViewModel >()
                .ForMember(contract => contract.Id, domain => domain
                .MapFrom(m => m.FilmId));

            CreateMap<Film, MovieViewModel.Movie>()
                .ForMember(contract => contract.Id, domain => domain
                .MapFrom(m => m.FilmId))
                .ForMember(contract => contract.Release, domain => domain
                .MapFrom(m => m.ReleaseYear));
        }
    }
}
