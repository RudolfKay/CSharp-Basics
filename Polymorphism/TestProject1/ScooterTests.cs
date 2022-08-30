using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using ScooterRental;

namespace TestProject1
{
    [TestClass]
    public class ScooterTests
    {
        private Scooter _scooter;

        [TestMethod]
        public void ScooterCreation_IDAndPricePerMinuteSetCorrectly()
        {
            _scooter = new Scooter("1", 0.2m);
            _scooter.Should().Be(1);
        }
    }
}
