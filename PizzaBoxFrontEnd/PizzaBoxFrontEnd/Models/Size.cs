using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBoxFrontEnd.Models
{
    public class Size
    {
        public Size()
        {
            Pizzas = new HashSet<Pizza>();
        }

        public int SizeId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<Pizza> Pizzas { get; set; }
    }
}
