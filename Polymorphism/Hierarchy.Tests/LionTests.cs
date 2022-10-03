using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hierarchy.Animals;
using FluentAssertions;
using Hierarchy.Diet;

namespace Hierarchy.Tests
{
    [TestClass]
    public class LionTests
    {
        [TestMethod]
        public void Lion_FeedMeat_FoodEaten()
        {
            Lion lion = new Lion("Chad", "Lion", 24, "Africa");
            lion.ToString().Should().Be("Lion [Chad, Africa, 24, 0]");

            lion.EatFood(new Meat(5));
            lion.ToString().Should().Be("Lion [Chad, Africa, 24, 5]");
        }

        [TestMethod]
        public void Lion_FeedVegetables_FoodNotEaten()
        {
            Lion lion = new Lion("Chad", "Lion", 24, "Africa");
            lion.ToString().Should().Be("Lion [Chad, Africa, 24, 0]");

            lion.EatFood(new Vegetable(5));
            lion.ToString().Should().Be("Lion [Chad, Africa, 24, 0]");
        }

        [TestMethod]
        public void Lion_MakeSound_SoundIsCorrect()
        {
            Lion lion = new Lion("Chad", "Lion", 24, "Africa");
            lion.MakeSound().Should().Be("...rrROAAARrr...");
        }
    }
}
