using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaBox.Storing.Mappers
{

    public class OrderMapper : IMapper<PizzaBox.Storing.Entities.Order, PizzaBox.Domain.Models.Order>
    {
        private CustomerMapper customerMapper = new CustomerMapper();
        private StoreMapper storeMapper = new StoreMapper();
        private OrderPizzaMapper orderPizzaMapper = new OrderPizzaMapper();
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
            List<Domain.Models.OrderPizza> orderpizzas = new List<Domain.Models.OrderPizza>();
            obj.OrderPizzas.ToList().ForEach(o => orderpizzas.Add(orderPizzaMapper.Map(o)));
            if(obj.Store != null && obj.Customer != null)
            {
                return new Domain.Models.Order
                {
                    OrderId = obj.OrderId,
                    CustomerId = obj.CustomerId,
                    StoreId = obj.StoreId,
                    Date = obj.Date,
                    Store = storeMapper.Map(obj.Store),
                    Customer = customerMapper.Map(obj.Customer),
                    OrderPizzas = orderpizzas
                };
            }
            else
            {
                return new Domain.Models.Order
                {
                    OrderId = obj.OrderId,
                    CustomerId = obj.CustomerId,
                    StoreId = obj.StoreId,
                    Date = obj.Date
                };
            }
            
        }
    }
}