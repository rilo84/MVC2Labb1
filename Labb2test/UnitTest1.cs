using MVC2Labb2.ViewModels;
using System;
using Xunit;

namespace Labb2test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            string model = null;
            //var model = new MovieViewModel.Movie()
            //{
            //    Id = 1,
            //    Title = "test"
            //};

            Assert.NotNull(model);
        }
    }
}
