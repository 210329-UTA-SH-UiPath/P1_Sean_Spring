namespace PizzaBox.Storing.Mappers
{

    public class OrderPizzaMapper : IMapper<PizzaBox.Storing.Entities.OrderPizza, PizzaBox.Domain.Models.OrderPizza>
    {
        private PizzaMapper pizzamapper = new PizzaMapper();
        public Entities.OrderPizza Map(Domain.Models.OrderPizza obj)
        {
            
            return new Entities.OrderPizza
            {
                OrderPizzaId = obj.OrderPizzaId,
                OrderId = obj.OrderId,
                PizzaId = obj.PizzaId,
                Quantity = obj.Quantity
            };
        }

        public Domain.Models.OrderPizza Map(Entities.OrderPizza obj)
        {
            return new Domain.Models.OrderPizza
            {
                OrderPizzaId = obj.OrderPizzaId,
                OrderId = obj.OrderId,
                PizzaId = obj.PizzaId,
                Quantity = obj.Quantity,

                Pizza = pizzamapper.Map(obj.Pizza)
            };
        }
    }
}