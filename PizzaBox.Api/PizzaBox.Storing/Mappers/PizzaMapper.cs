using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaBox.Storing.Mappers
{

    public class PizzaMapper : IMapper<PizzaBox.Storing.Entities.Pizza, PizzaBox.Domain.Models.Pizza>
    {
        private CrustMapper crustmapper = new CrustMapper();
        private SizeMapper sizemapper = new SizeMapper();
        private PizzaToppingMapper pizzatoppingmapper = new PizzaToppingMapper();
        public Entities.Pizza Map(Domain.Models.Pizza obj)
        {
            return new Entities.Pizza
            {
                PizzaId = obj.PizzaId,
                Name = obj.Name,
                SizeId = obj.SizeId,
                CrustId = obj.CrustId
            };
        }

        public Domain.Models.Pizza Map(Entities.Pizza obj)
        {
            List<Domain.Models.PizzaTopping> pizzaToppings = new List<Domain.Models.PizzaTopping>();
            obj.PizzaToppings.ToList().ForEach(o => pizzaToppings.Add(pizzatoppingmapper.Map(o)));
            if (obj.Crust != null)
            {
                return new Domain.Models.Pizza
                {
                    PizzaId = obj.PizzaId,
                    Name = obj.Name,
                    SizeId = obj.SizeId,
                    CrustId = obj.CrustId,

                    Crust = crustmapper.Map(obj.Crust),
                    Size = sizemapper.Map(obj.Size),

                    PizzaToppings = pizzaToppings
                };
            }
            else
            {
                return new Domain.Models.Pizza
                {
                    PizzaId = obj.PizzaId,
                    Name = obj.Name,
                    SizeId = obj.SizeId,
                    CrustId = obj.CrustId
                };
            }
           
        }
    }
}