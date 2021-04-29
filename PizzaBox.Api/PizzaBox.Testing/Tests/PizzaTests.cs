using System;
using PizzaBox.Storing.Entities;
using Xunit;


namespace PizzaBox.Testing.Tests
{
    
    public class PizzaTests
    {

        Pizza pizza = new Pizza
        {
            Name = "Name",
            PizzaId = 1,
            SizeId = 1,
            CrustId =1
        };

        [Fact]
        public void TestPizzaId()
        {

            var sut = pizza.PizzaId;

            bool istwo = sut == 1;

            Assert.True(istwo);
        }
        [Fact]
        public void TestCrustId()
        {

            var sut = pizza.CrustId;

            bool istwo = sut == 1;

            Assert.True(istwo);
        }
        [Fact]
        public void TestSizeId()
        {

            var sut = pizza.SizeId;

            bool istwo = sut == 1;

            Assert.True(istwo);
        }
        //[Fact]
        //public void TestName()
        //{
        //    //Given
        //    var sut = new Pizza();

        //    sut.Name = "Test";
        //    //When
        //    var actual = sut.Name;
        //    //Then

        //    Assert.True(actual == "Test");
        //}

        //[Fact]
        //public void TestGetPizzas()
        //{
        //    var sut = PizzaController.GetPizzas();

        //    bool isNull = sut == null;

        //    Assert.False(isNull);
        //}

        //[Fact]
        //public void TestGetCrustsById()
        //{
        //    var sut = PizzaController.GetPizzaById(1);

        //    bool isNull = sut == null;

        //    Assert.False(isNull);
        //}
    }
}