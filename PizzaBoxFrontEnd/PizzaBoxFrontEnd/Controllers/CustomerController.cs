using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaBoxFrontEnd.Models;

namespace PizzaBoxFrontEnd.Controllers
{
    public class CustomerController : Controller
    {
        Client client = new Client();

        
        public IActionResult Index()
        {
            var customer = client.GetAllCustomers();
            return View(customer);
        }

        public IActionResult GetByName(string name)
        {
            var customer = client.GetCustomerByName(name);
            if (customer == null )
            {
                return NotFound($"The customer with name {name} is not in the database");
            }
            else 
                return View("IndexByName", customer);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("Name, Address")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                client.AddCustomer(customer);
                return RedirectToAction("Index");
            }

            else
            return View();
        } 
    }
}
