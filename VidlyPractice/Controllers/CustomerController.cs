using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Services.Description;
using VidlyPractice.Models;
using System.Data.Entity;

namespace VidlyPractice.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var customers = _context.Customer.Include(c => c.MembershipType).ToList();

            return View(customers);

            //var customer = new List<Customer>()
            //{
            //    new Customer { Id = 0, Name = "Mahdokht Sobhanipoor"},
            //    new Customer { Id = 1, Name = "Nazanin Sarkheil"},
            //    new Customer { Id = 2, Name = "Ehsan Soltani"},
            //    new Customer { Id = 3, Name = "Sina Maleki Pak"}
            //};

            //return View(customer);
        }

        [Route("Customer/Detail/{customerId}")]
        public ActionResult Detail(int customerId)
        {
            if (customerId == 0)
            {
                return HttpNotFound();
            }
            var customer = _context.Customer
                .Include(c => c.MembershipType)
                .SingleOrDefault(c => c.Id == customerId);
            return View(customer);
        }
    }
}