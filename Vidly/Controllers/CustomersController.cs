using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            var customers = GetCustomers();
            return View(customers);
        }

        public ActionResult Details(int Id)
        {
            var customers = GetCustomers();

            Customers customer = customers.Where(c => c.Id == Id).FirstOrDefault();
            
            if(customer == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(customer);
            }
                       
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