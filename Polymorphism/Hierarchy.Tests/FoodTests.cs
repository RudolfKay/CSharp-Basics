using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hierarchy.Exceptions;
using FluentAssertions;
using Hierarchy.Diet;
using System;

namespace Hierarchy.Tests
{
    [TestClass]
    public class FoodTests
    {
        [TestMethod]
        public void Food_GetQuantity_ReturnsQuantity()
        {
            Food meat = new Meat(10);
            Food vegetable = new Vegetable(15);

            meat.GetQuantity().Should().Be(10);
            vegetable.GetQuantity().Should().Be(15);
        }

        [TestMethod]
        public void Food_NewFoodWithInvalidFoodQuantity_ThrowsInvalidFoodQuantityException()
        {
            Action act1 = () => new Meat(-1);
            Action act2 = () => new Vegetable(-1);

            act1.Should().Throw<InvalidFoodQuantityException>().
                WithMessage("Food quantity is invalid");
            act2.Should().Throw<InvalidFoodQuantityException>().
                WithMessage("Food quantity is invalid");
        }

        [TestMethod]
        public void Food_SetFoodQuantity_QuantityIsSet()
        {
            Food meat = new Meat(10);
            Food vegetable = new Vegetable(15);
            meat.GetQuantity().Should().Be(10);
            vegetable.GetQuantity().Should().Be(15);

            meat.SetQuantity(5);
            vegetable.SetQuantity(10);
            meat.GetQuantity().Should().Be(5);
            vegetable.GetQuantity().Should().Be(10);
        }

        [TestMethod]
        public void Food_SetFoodWithInvalidFoodQuantity_ThrowsInvalidFoodQuantityException()
        {
            Food meat = new Meat(10);
            Food vegetable = new Vegetable(15);
            meat.GetQuantity().Should().Be(10);
            vegetable.GetQuantity().Should().Be(15);

            Action act1 = () => meat.SetQuantity(-1);
            Action act2 = () => vegetable.SetQuantity(-1);

            act1.Should().Throw<InvalidFoodQuantityException>().
                WithMessage("Food quantity is invalid");
            act2.Should().Throw<InvalidFoodQuantityException>().
                WithMessage("Food quantity is invalid");
        }
    }
}
