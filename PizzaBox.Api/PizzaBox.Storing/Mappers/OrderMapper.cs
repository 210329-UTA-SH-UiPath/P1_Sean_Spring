namespace PizzaBox.Storing.Mappers
{

    public class OrderMapper : IMapper<PizzaBox.Storing.Entities.Order, PizzaBox.Domain.Models.Order>
    {
        private CustomerMapper customerMapper = new CustomerMapper();
        private StoreMapper storeMapper = new StoreMapper();
        public Entities.Order Map(Domain.Models.Order obj)
        {
            return new Entities.Order
            {
                OrderId = obj.OrderId,
                CustomerId = obj.CustomerId,
                StoreId = obj.StoreId,
                Date = obj.Date
            };
        }

        public Domain.Models.Order Map(Entities.Order obj)
        {
            return new Domain.Models.Order
            {
                OrderId = obj.OrderId,
                CustomerId = obj.CustomerId,
                StoreId = obj.StoreId,
                Date = obj.Date,

                Store = storeMapper.Map(obj.Store),
                Customer = customerMapper.Map(obj.Customer)
            };
        }
    }
}