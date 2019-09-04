using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using VidlyPractice.Models;
using VidlyPractice.ViewModels;

namespace VidlyPractice.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
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

        [Route("Customers/Edit/{customerId}")]
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
        [ValidateAntiForgeryToken]
        public ActionResult Save(CustomerFormViewModel customerViewModel)  // not using customer because of data annotation in ViewModel  [Required], messages, ...
        {                                                                   // I dont want to pollute Customer.cs with annotations
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel()
                {
                    Id = customerViewModel.Id,
                    Name = customerViewModel.Name,
                    IsSubscribedToNewsLetter = customerViewModel.IsSubscribedToNewsLetter,
                    BirthDate = customerViewModel.BirthDate,
                    MembershipTypeId = customerViewModel.MembershipTypeId,
                    MembershipTypes = _context.MembershipType.ToList()
                };

                return View("CustomerForm", viewModel);
            }
            
            // if information is ok
            if (customerViewModel.Id == 0)                   // customer is new
            {
                var customer = new Customer()
                {
                    Id = customerViewModel.Id,
                    Name = customerViewModel.Name,
                    IsSubscribedToNewsLetter = customerViewModel.IsSubscribedToNewsLetter,
                    BirthDate = customerViewModel.BirthDate,
                    MembershipTypeId = customerViewModel.MembershipTypeId,
                };
                _context.Customer.Add(customer);                
            }
            else                                    // edit an existing customer
            {
                var customerInDb = _context.Customer.SingleOrDefault(c => c.Id == customerViewModel.Id);
                if (customerInDb == null)
                {
                    return HttpNotFound();
                }

                customerInDb.Name = customerViewModel.Name;
                customerInDb.MembershipTypeId = customerViewModel.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customerViewModel.IsSubscribedToNewsLetter;
                customerInDb.BirthDate = customerViewModel.BirthDate;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }
    }
}