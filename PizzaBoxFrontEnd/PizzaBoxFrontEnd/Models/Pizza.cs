using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBoxFrontEnd.Models
{
    public class Pizza
    {
        public Pizza()
        {
            OrderPizzas = new HashSet<OrderPizza>();
            PizzaToppings = new HashSet<PizzaTopping>();
        }
        public decimal price;
        public int PizzaId { get; set; }
        public string Name { get; set; }
        public int CrustId { get; set; }
        public int SizeId { get; set; }

        public virtual Crust Crust { get; set; }
        public virtual Size Size { get; set; }
        public virtual ICollection<OrderPizza> OrderPizzas { get; set; }
        public virtual ICollection<PizzaTopping> PizzaToppings { get; set; }


        public void setPrice()
        {
                decimal pizzaPrice = 0;
                pizzaPrice += Size.Price;
                pizzaPrice += Crust.Price;
                foreach (var topping in PizzaToppings)
                {
                    pizzaPrice += topping.Topping.Price;
                }

                price += pizzaPrice;
            
        }
    }
}
