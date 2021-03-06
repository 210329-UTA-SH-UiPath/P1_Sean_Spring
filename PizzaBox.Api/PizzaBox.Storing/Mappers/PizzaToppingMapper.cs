namespace PizzaBox.Storing.Mappers
{

    public class PizzaToppingMapper : IMapper<PizzaBox.Storing.Entities.PizzaTopping, PizzaBox.Domain.Models.PizzaTopping>
    {
        private ToppingMapper toppingMapper = new ToppingMapper();
        public Entities.PizzaTopping Map(Domain.Models.PizzaTopping obj)
        {
            
            return new Entities.PizzaTopping
            {
                PizzaToppingId = obj.PizzaToppingId,
                PizzaId = obj.PizzaId,
                ToppingId = obj.ToppingId
            };
        }

        public Domain.Models.PizzaTopping Map(Entities.PizzaTopping obj)
        {
            if (obj.Topping != null )
            {
                return new Domain.Models.PizzaTopping
                {
                    PizzaToppingId = obj.PizzaToppingId,
                    PizzaId = obj.PizzaId,
                    ToppingId = obj.ToppingId,

                    Topping = toppingMapper.Map(obj.Topping)
                };
            }
            else
            {
                return new Domain.Models.PizzaTopping
                {
                    PizzaToppingId = obj.PizzaToppingId,
                    PizzaId = obj.PizzaId,
                    ToppingId = obj.ToppingId,
                };
            }
            
        }
    }
}