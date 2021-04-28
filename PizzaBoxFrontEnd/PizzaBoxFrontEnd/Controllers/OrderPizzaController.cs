using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaBoxFrontEnd.Models;

namespace PizzaBoxFrontEnd.Controllers
{
    public class OrderPizzaController : Controller
    {
        Client client = new Client();
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet] 
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("OrderId, PizzaId, Quantity")] OrderPizza orderpizza)
        {
            if (ModelState.IsValid)
            {
                client.AddOrderPizza(orderpizza);
                return View("Index");
                
            }

            else
                return View();
        }
    }
}
