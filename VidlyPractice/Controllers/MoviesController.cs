using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using VidlyPractice.Models;

namespace VidlyPractice.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movie
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var movie = _context.Movie.Include(m => m.Genre).ToList();

            return View(movie);
            //var movie = new Movie()
            //{
            //    Id = 1,
            //    Name = "Matrix"
            //};
            ////var movie = new List<Movie>();
            //{
            //    new Movie { Name = "Matrix"},
            //    new Movie { Name = "Terminator"},
            //    new Movie { Name = "God Father"}
            //};

            ////return View(movie);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movie.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel()
            {
                Genres = _context.Genre.ToList(),
                Id = movie.Id,
                Name = movie.Name,
                GenreId = movie.GenreId,
                ReleaseDate = movie.ReleaseDate,
                DateAdded = movie.DateAdded,
                NumberInStock = movie.NumberInStock
            };

            return View("MovieForm", viewModel);
        }

        public ActionResult New()
        {
            var viewModel = new MovieFormViewModel()
            {
                Genres = _context.Genre.ToList()
            };

            return View("MovieForm", viewModel);

        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)                            // new movies
                _context.Movie.Add(movie);
            else
            {
                var movieInDb = _context.Movie.Single(m => m.Id == movie.Id);
                if (movieInDb == null)
                    return HttpNotFound();
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.DateAdded = movie.DateAdded;
                movieInDb.NumberInStock = movie.NumberInStock;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }
    }
}