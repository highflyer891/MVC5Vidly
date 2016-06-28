using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        public ActionResult Index()
        {
            var customers = GetMovies();
            return View(customers);
        }

        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name="Shrek!" };

            var customers = new List<Customers>()
            {
                new Customers {Name = "Customer 1" },
                new Customers {Name = "Customer 2" }
            };

            var randomMovieViewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(randomMovieViewModel);
            // return Content("Hello World");
            //return HttpNotFound();
            //return new EmptyResult();

            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });

        }

        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
               new Movie {Id=1, Name="Wall-E" },
               new Movie {Id=2, Name="Shrek" }
            };
        }


        public ActionResult Edit(int Id)
        {
            return Content("id=" + Id);
        }

        //movies
        public ActionResult Index(int? pageIndex,string sortBy)
        {
            if(!pageIndex.HasValue)
            {
                pageIndex = 1;
            }

            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content(string.Format("PageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }
        [Route("movies/released/{year}/{month:regex(\\d{4}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}