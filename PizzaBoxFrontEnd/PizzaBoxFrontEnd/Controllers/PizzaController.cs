using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaBoxFrontEnd.Models;
using System.Threading;

namespace PizzaBoxFrontEnd.Controllers
{
    public class PizzaController : Microsoft.AspNetCore.Mvc.Controller
    {
        Client client = new Client();

        [Microsoft.AspNetCore.Mvc.HttpPost]
        public IActionResult Create(int orderid, int sizeid, int crustid, int[] toppingid, int quantity)
        {
            Pizza customPizza = new Pizza
            {
                Name = "CustomPizza",
                SizeId = sizeid,
                CrustId = crustid
            };

            client.AddPizza(customPizza);
            Thread.Sleep(1000);
            var newPizza = client.GetRecentlyAddedPizza();


            OrderPizza orderPizza = new OrderPizza
            {
                OrderId = orderid,
                PizzaId = newPizza.PizzaId,
                Quantity = quantity
            };
            client.AddOrderPizza(orderPizza);

            foreach (var item in toppingid)
            {
                PizzaTopping pizzaTopping = new PizzaTopping
                {
                    PizzaId = newPizza.PizzaId,
                    ToppingId = item
                };
                client.AddPizzaTopping(pizzaTopping);
            }


            return View("Index");
        }
    }
}
