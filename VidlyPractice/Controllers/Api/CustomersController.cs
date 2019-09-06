using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VidlyPractice.Models;
using System.Data.Entity;
using VidlyPractice.Dtos;

namespace VidlyPractice.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // /Api/Customers       -> list of all customers
        [HttpGet]
        public IHttpActionResult GetCustomers()
        {
            var customers = _context.Customer.Include(c => c.MembershipType).ToList();

            var customizedResult = customers.Select(x => new CustomerDto
            {
                Name = x.Name,
                BirthDate = x.BirthDate,
                IsSubscribedToNewsLetter = x.IsSubscribedToNewsLetter,
                MembershipTypeDtoId = x.MembershipTypeId,
                Membership = x.MembershipType.Name
            });

            return Ok(customizedResult);
        }

        //      /Api/Customers/id       -> get a customer
        [HttpGet]
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customer.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            var customerDto = new CustomerDto()
            {
                Id = customer.Id,
                Name = customer.Name,
                BirthDate = customer.BirthDate,
                MembershipTypeDtoId = customer.MembershipTypeId,
                Membership = customer.MembershipType.Name,
                IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter
            };
            return Ok(customerDto);
        }

        //      /api/customers/         -> Create a new customer
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Data are not valid");

            var customer = _context.Customer.SingleOrDefault(c => c.Name == customerDto.Name);
            if (customer != null && customer.Name == customerDto.Name)
                return BadRequest("A customer with the same name already exist");

            var newCustomer = new Customer()
            {
                Name = customerDto.Name,
                BirthDate = customerDto.BirthDate,
                IsSubscribedToNewsLetter = customerDto.IsSubscribedToNewsLetter,
                MembershipTypeId = customerDto.MembershipTypeDtoId
            };

            _context.Customer.Add(newCustomer);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + newCustomer.Id), customerDto);
        }

        //      /api/customers/1        -> Update(Edit) a customer
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Data is not valid");

            var customerInDb = _context.Customer.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                return NotFound();

            customerInDb.Name = customerDto.Name;
            customerInDb.BirthDate = customerDto.BirthDate;
            customerInDb.IsSubscribedToNewsLetter = customerDto.IsSubscribedToNewsLetter;
            customerInDb.MembershipTypeId = customerDto.MembershipTypeDtoId;

            _context.SaveChanges();

            return Ok(customerDto);
        }

        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customer = _context.Customer.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return NotFound();

            _context.Customer.Remove(customer);
            _context.SaveChanges();
            return Ok("customer " + customer.Name + " deleted.");
        }
        
    }
}
