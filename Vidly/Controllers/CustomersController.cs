using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
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
        // GET: Customers
        public ActionResult Index()
        {
            //var customers = GetCustomers();
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }
        public ActionResult Details(int id)
        {
            var customers = GetCustomers();

            Customers customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            
            if(customer == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(customer);
            }
                       
        }

        public ActionResult New()
        {
            return View();
        }


        private List<Customers> GetCustomers()
        {
            return new List<Customers>()
            {
                new Customers { Id = 1, Name = "John Smith" },
                new Customers {Id = 2 ,Name = "Mary Williams" }
            };
        }


    }
}