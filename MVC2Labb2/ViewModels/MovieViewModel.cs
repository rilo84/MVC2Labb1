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
        public int MoviesInPage { get; set; }
        public int Pages { get; set; }
        public int CurrentPage { get; set; }
        public List<Movie> Movies { get; set; } = new List<Movie>();

        public MovieViewModel(string SortColumn, string SortOrder, int CurrentPage, int MoviesInPage)
        {
            this.SortColumn = SortColumn;
            this.SortOrder = SortOrder;
            this.CurrentPage = CurrentPage;
            this.MoviesInPage = MoviesInPage;
        }
        public class Movie
        {
            public string Title { get; set; }
            public string Release { get; set; }
            public decimal RentalRate { get; set; }
        }
    }
}
