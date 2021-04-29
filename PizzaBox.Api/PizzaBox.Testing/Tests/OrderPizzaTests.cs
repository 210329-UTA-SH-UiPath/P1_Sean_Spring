using System;
using System.Collections.Generic;
using PizzaBox.Storing.Entities;
using Xunit;

namespace PizzaBox.Testing.Tests
{
    public class OrderPizzaTests
    {
        OrderPizza orderPizza = new OrderPizza
        {
            OrderPizzaId = 1,
            OrderId = 1,
            PizzaId = 1,
            Quantity = 1
        };

        [Fact]
        public void TestOrderPizzaId()
        {

            var sut = orderPizza.OrderPizzaId;

            bool istwo = sut == 1;

            Assert.True(istwo);
        }
        [Fact]
        public void TestOrderId()
        {

            var sut = orderPizza.OrderPizzaId;

            bool istwo = sut == 1;

            Assert.True(istwo);
        }
        [Fact]
        public void TestPizzaId()
        {

            var sut = orderPizza.PizzaId;

            bool istwo = sut == 1;

            Assert.True(istwo);
        }
        [Fact]
        public void TestQuantity()
        {

            var sut = orderPizza.Quantity;

            bool istwo = sut == 1;

            Assert.True(istwo);
        }
        //[Fact]
        //public void TestGetOrderPizzasByOrderID()
        //{
        //    var sut = OrderPizzaController.GetOrderPizzasByOrderID(1);

        //    bool isNull = sut == null;

        //    Assert.False(isNull);
        //}
    }
}