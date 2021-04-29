using System;
using System.Collections.Generic;
using PizzaBox.Storing.Entities;
using Xunit;

namespace PizzaBox.Testing.Tests
{

    public class OrderTests
    {
        Order order = new Order
        {
            OrderId = 1,
            CustomerId = 1,
            StoreId = 1,
            Date = DateTime.Now
        };

        [Fact]
        public void TestOrderId()
        {

            var sut = order.OrderId;

            bool istwo = sut == 1;

            Assert.True(istwo);
        }
        [Fact]
        public void TestStoreId()
        {

            var sut = order.StoreId;

            bool istwo = sut == 1;

            Assert.True(istwo);
        }
        [Fact]
        public void TestCustomerId()
        {

            var sut = order.CustomerId;

            bool istwo = sut == 1;

            Assert.True(istwo);
        }
        [Fact]
        public void TestDate()
        {

            var sut = order.OrderId;

            bool istwo = sut == null;

            Assert.False(istwo);
        }
        //[Fact]
        //public void TestGetOrderByCustomerId()
        //{
        //    var sut = OrderController.GetOrderByCustomerId(1);

        //    bool isNull = sut == null;

        //    Assert.False(isNull);
        //}
    }
}