using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hierarchy.Exceptions;
using Hierarchy.Animals;
using FluentAssertions;
using Hierarchy.Diet;
using System;

namespace Hierarchy.Tests
{
    [TestClass]
    public class CatTests
    {
        [TestMethod]
        public void Cat_NewCatWithInvalidBreed_ThrowsInvalidBreedException()
        {
            Action act = () =>
                new Cat("Tom", "Cat", 5, "Europe", "");

            act.Should().Throw<InvalidBreedException>().
                WithMessage("Cat breed is invalid");
        }

        [TestMethod]
        public void Cat_FeedVegetablesAndMeat_AllFoodEaten()
        {
            Cat cat = new Cat("Tom", "Cat", 5, "Europe", "Sphinx");
            cat.ToString().Should().Be("Cat [Tom, Sphinx, Europe, 5, 0]");

            cat.EatFood(new Meat(5));
            cat.ToString().Should().Be("Cat [Tom, Sphinx, Europe, 5, 5]");

            cat.EatFood(new Vegetable(5));
            cat.ToString().Should().Be("Cat [Tom, Sphinx, Europe, 5, 10]");
        }

        [TestMethod]
        public void Cat_MakeSound_SoundIsCorrect()
        {
            Cat cat = new Cat("Tom", "Cat", 5, "Europe", "Sphinx");
            cat.MakeSound().Should().Be("Meow...Mrr..");
        }
    }
}
