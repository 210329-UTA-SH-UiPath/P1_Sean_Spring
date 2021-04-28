using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBoxFrontEnd.Controllers
{
    public class OrderController : Controller
    {
        Client client = new Client();
        public IActionResult GetByCustomerId(int id)
        {
            var orders = client.GetOrdersByCustomerId(id);
            return View(orders);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    }
}
