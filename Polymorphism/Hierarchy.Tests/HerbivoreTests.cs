using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hierarchy.Animals;
using FluentAssertions;
using Hierarchy.Diet;

namespace Hierarchy.Tests
{
    [TestClass]
    public class HerbivoreTests
    {
        [TestMethod]
        public void Herbivore_FeedVegetables_FoodEaten()
        {
            Zebra zebra = new Zebra("Steve", "Zebra", 15, "Africa");
            Mouse mouse = new Mouse("Pepe", "Mouse", 0.5, "Asia");
            zebra.ToString().Should().Be("Zebra [Steve, Africa, 15, 0]");
            mouse.ToString().Should().Be("Mouse [Pepe, Asia, 0,5, 0]");

            zebra.EatFood(new Vegetable(5));
            mouse.EatFood(new Vegetable(5));
            zebra.ToString().Should().Be("Zebra [Steve, Africa, 15, 5]");
            mouse.ToString().Should().Be("Mouse [Pepe, Asia, 0,5, 5]");
        }

        [TestMethod]
        public void Herbivore_FeedMeat_FoodNotEaten()
        {
            Zebra zebra = new Zebra("Steve", "Zebra", 15, "Africa");
            Mouse mouse = new Mouse("Pepe", "Mouse", 0.5, "Asia");
            zebra.ToString().Should().Be("Zebra [Steve, Africa, 15, 0]");
            mouse.ToString().Should().Be("Mouse [Pepe, Asia, 0,5, 0]");

            zebra.EatFood(new Meat(5));
            mouse.EatFood(new Meat(5));
            zebra.ToString().Should().Be("Zebra [Steve, Africa, 15, 0]");
            mouse.ToString().Should().Be("Mouse [Pepe, Asia, 0,5, 0]");
        }

        [TestMethod]
        public void Zebra_MakeSound_SoundIsCorrect()
        {
            Zebra zebra = new Zebra("Steve", "Zebra", 15, "Africa");
            zebra.MakeSound().Should().Be("...NEEiiigh! Clop, clop, clop...");
        }

        [TestMethod]
        public void Mouse_MakeSound_SoundIsCorrect()
        {
            Mouse mouse = new Mouse("Pepe", "Mouse", 0.5, "Asia");
            mouse.MakeSound().Should().Be("...squeek..squeeeeek...");
        }
    }
}
