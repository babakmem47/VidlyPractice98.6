using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using VidlyPractice.Models;

namespace VidlyPractice.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        private ApplicationDbContext _context;

        public MovieController()
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

        public ActionResult Detail(int id)
        {
            var movie = _context.Movie
                .Include(m => m.Genre)
                .SingleOrDefault(m => m.Id == id);

            return View(movie);
        }
    }
}