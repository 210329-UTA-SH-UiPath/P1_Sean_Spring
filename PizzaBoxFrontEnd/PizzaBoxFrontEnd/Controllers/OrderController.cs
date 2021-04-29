using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using PizzaBoxFrontEnd.Models;

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

        public IActionResult GetByStoreId(int storeid)
        {
            var orders = client.GetOrdersByStoreId(storeid);
            return View(orders);
        }

        [HttpPost]
        public IActionResult Create([Bind("CustomerId, StoreId")] Order order)
        {
            order.Date = DateTime.Now;
            if (ModelState.IsValid)
            {
                client.AddOrder(order);
                Thread.Sleep(1000);
                var newOrder = client.GetRecentlyAddedOrder();
                return View("NewOrder", newOrder);
            }

            else
                return View();
        }

        [HttpGet]
        public IActionResult Return()
        {
            var newOrder = client.GetRecentlyAddedOrder();
            return View("NewOrder", newOrder);
        }

        [HttpGet]
        public IActionResult IndexById(int id)
        {
            var order = client.GetOrderById(id);
            order.setPrice();
            if (order == null)
            {
                return NotFound($"The order with id {id} is not in the database");
            }
            else
                return View("IndexById", order);
        }
    }
}
