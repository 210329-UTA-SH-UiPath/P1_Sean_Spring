using System;
using System.Collections.Generic;
using System.IO;
using PizzaBox.Storing.Entities;

using Xunit;

namespace PizzaBox.Testing.Tests
{
    
    public class CustomerTests
    {
        Customer customer = new Customer
        {
            CustomerId = 1,
            Name = "Sean",

        };
        [Fact]
        public void TestCustomerId()
        {

            var sut = customer.CustomerId;

            bool istwo = sut == 1;

            Assert.True(istwo);
        }

        [Fact]
        public void TestCustomerName()
        {
            var sut = customer.Name;

            bool isNull = sut == "Sean";

            Assert.True(isNull);
        }
        //[Fact]
        //public void TestGetCustomerByName()
        //{
        //    using (var input = new StringReader("Sean"))
        //    {
        //        Console.SetIn(input);
        //        var sut = CustomerController.GetCustomerByName();

        //        bool isNull = sut == null;

        //        Assert.False(isNull);
        //    }

        //}
    }
}