using System;
using System.Collections.Generic;
using PizzaBox.Client.Controller;
using PizzaBox.Storing.Entities;
using Xunit;

namespace PizzaBox.Testing.Tests
{
    public class StoreTests
    {
        [Fact]
        public void TestGetStores()
        {
            var sut = StoreController.GetStores();

            bool isNull = sut == null;

            Assert.False(isNull);
        }

        [Fact]
        public void TestGetStoresById()
        {
            var sut = StoreController.GetStoreById(1);

            bool isNull = sut == null;

            Assert.False(isNull);
        }
    }
}