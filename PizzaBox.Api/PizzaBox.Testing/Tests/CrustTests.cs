using System;
using System.Collections.Generic;
using PizzaBox.Storing.Entities;
using PizzaBox.Api.Controllers;
using Xunit;

namespace PizzaBox.Testing.Tests
{
    public class CrustTests
    {
        Crust crust = new Crust
        {
            CrustId = 2,
            Name = "Crust",
            Price = 4
        };

        [Fact]
        public void TestCrustId()
        {
            
            var sut = crust.CrustId;

            bool istwo = sut == 2;

            Assert.True(istwo);
        }

        [Fact]
        public void TestCrustName()
        {
            var sut = crust.Name;

            bool isNull = sut == "Crust";

            Assert.True(isNull);
        }

        [Fact]
        public void TestCrustPrice()
        {
            var sut = crust.Price;

            bool isNull = sut == 4;

            Assert.True(isNull);
        }
    }
}