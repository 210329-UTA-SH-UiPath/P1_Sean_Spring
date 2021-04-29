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
        public IActionResult ViewOrderPizza(int id)
        {
            var orderpizzas = client.GetOrderPizzaByOrderId(id);
            foreach(var item in orderpizzas)
            {
                item.Pizza.setPrice();
            }
            return View(orderpizzas);
        }

        [HttpGet] 
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            client.DeleteOrderPizza(id);
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
