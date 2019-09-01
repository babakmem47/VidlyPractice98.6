using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using VidlyPractice.Models;
using VidlyPractice.ViewModels;

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

        [Route("Customer/Edit/{customerId}")]
        public ActionResult Edit(int customerId)
        {
            if (customerId == 0)
            {
                return HttpNotFound();
            }
            var customer = _context.Customer.Single(c => c.Id == customerId);

            var viewModel = new CustomerFormViewModel()
            {
                Id = customer.Id,
                Name = customer.Name,
                IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter,
                BirthDate = customer.BirthDate,
                MembershipTypeId = customer.MembershipTypeId,
                MembershipTypes = _context.MembershipType.ToList()

            };
            return View("CustomerForm", viewModel);
        }

        public ActionResult New()
        {
            var viewModel = new CustomerFormViewModel()
            {
                MembershipTypes = _context.MembershipType.ToList()
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (customer.Id == 0)                   // customer is new
            {
                _context.Customer.Add(customer);                
            }
            else                                    // edit an existing customer
            {
                var customerInDb = _context.Customer.SingleOrDefault(c => c.Id == customer.Id);
                if (customerInDb == null)
                {
                    return HttpNotFound();
                }

                customerInDb.Name = customer.Name;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
                customerInDb.BirthDate = customer.BirthDate;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Customer");
        }
    }
}