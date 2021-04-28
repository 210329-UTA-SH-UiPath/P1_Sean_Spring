using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBoxFrontEnd.Models
{
    public class Order
    {
        public Order()
        {
            OrderPizzas = new HashSet<OrderPizza>();
        }

        public decimal price;

        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int StoreId { get; set; }
        public DateTime Date { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Store Store { get; set; }
        public virtual ICollection<OrderPizza> OrderPizzas { get; set; }

        public void setPrice()
        {
            
            foreach (var item in OrderPizzas)
            {
                decimal pizzaPrice = 0;
                pizzaPrice += item.Pizza.Size.Price;
                pizzaPrice += item.Pizza.Crust.Price;
                foreach (var topping in item.Pizza.PizzaToppings)
                {
                    pizzaPrice += topping.Topping.Price;
                }

                price += pizzaPrice * item.Quantity;
            } 
        }
    }
}
