using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hierarchy.Exceptions;
using Hierarchy.Animals;
using FluentAssertions;
using Hierarchy.Diet;
using System;

namespace Hierarchy.Tests
{
    [TestClass]
    public class AnimalTests
    {
        [TestMethod]
        public void NewAnimal_AnimalCreatedCorrectly()
        {
            Animal zebra = new Zebra("Steve", "Zebra", 12.3, "Africa");
            Animal lion = new Lion("Tom", "Lion", 24.0, "Europe");
            Food food1 = new Vegetable(1);
            Food food2 = new Meat(1);
            lion.EatFood(food1);
            lion.EatFood(food2);
            zebra.EatFood(food1);
            zebra.EatFood(food2);

            lion.ToString().Should().Be($"Lion [Tom, Europe, 24, 1]");
            zebra.ToString().Should().Be($"Zebra [Steve, Africa, 12,3, 1]");
        }

        [TestMethod]
        public void Animal_NewMammalWithInvalidName_ThrowsInvalidNameException()
        {
            Action act = () =>
                new Zebra("", "Zebra", 12.3, "Africa");

            act.Should().Throw<InvalidNameException>().
                WithMessage("Name is invalid");
        }

        [TestMethod]
        public void Animal_NewMammalWithInvalidType_ThrowsInvalidTypeException()
        {
            Action act = () =>
                new Zebra("Steve", "", 12.3, "Africa");

            act.Should().Throw<InvalidTypeException>().
                WithMessage("Type is invalid");
        }

        [TestMethod]
        public void Animal_NewMammalWithInvalidWeight_ThrowsInvalidWeightException()
        {
            Action act1 = () =>
                new Zebra("Steve", "Zebra", -12.3, "Africa");
            Action act2 = () =>
                new Zebra("Steve", "Zebra", 0, "Africa");

            act1.Should().Throw<InvalidWeightException>().
                WithMessage("Weight is invalid");
            act2.Should().Throw<InvalidWeightException>().
                WithMessage("Weight is invalid");
        }

        [TestMethod]
        public void Animal_NewAnimalWithInvalidRegion_ThrowsInvalidRegionException()
        {
            Action act = () =>
                new Zebra("Steve", "Zebra", 12.3, "");

            act.Should().Throw<InvalidRegionException>().
                WithMessage("Region is invalid");
        }
    }
}
