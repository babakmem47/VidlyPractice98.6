using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyPractice.Models;

namespace VidlyPractice.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Index()
        {
            //var movie = new Movie()
            //{
            //    Id = 1,
            //    Name = "Matrix"
            //};
            var movie = new List<Movie>();
            //{
            //    new Movie { Name = "Matrix"},
            //    new Movie { Name = "Terminator"},
            //    new Movie { Name = "God Father"}
            //};

            return View(movie);
        }
    }
}