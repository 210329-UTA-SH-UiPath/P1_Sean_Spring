using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBoxFrontEnd.Models
{
    public class Topping
    {
        public Topping()
        {
            PizzaToppings = new HashSet<PizzaTopping>();
        }

        public int ToppingId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public virtual ICollection<PizzaTopping> PizzaToppings { get; set; }
    }
}
