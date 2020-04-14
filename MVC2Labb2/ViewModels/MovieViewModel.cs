using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC2Labb2.ViewModels
{
    public class MovieViewModel
    {
        public string SortColumn { get; set; }
        public string SortOrder { get; set; }
        public List<Movie> Movies { get; set; } = new List<Movie>();
        public class Movie
        {
            public string Title { get; set; }
            public string Release { get; set; }
        }
    }
}
