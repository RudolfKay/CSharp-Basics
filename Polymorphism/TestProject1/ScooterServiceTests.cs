using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using ScooterRental;
using ScooterRental.Interfaces;
using ScooterRental.Exceptions;

namespace TestProject1
{
    [TestClass]
    public class ScooterServiceTests
    {
        private IScooterService _scooterService;
        private List<Scooter> _inventory;

        [TestInitialize]
        public void Setup()
        {
            _inventory = new List<Scooter>();
            _scooterService = new ScooterService(_inventory);
        }

        [TestMethod]
        public void AddScooter_AddValidScooter_ScooterAdded()
        {
            _scooterService.AddScooter("1",0.2m);
            _inventory.Count.Should().Be(1);
        }

        [TestMethod]
        public void AddScooter_AddScooterTwice_ThrowsDuplicateScooterException()
        {
            _scooterService.AddScooter("1",0.2m);

            Action act = () =>
                _scooterService.AddScooter("1",0.2m);

            act.Should().Throw<DuplicateScooterException>()
                .WithMessage("Scooter with ID 1 already exists");
        }

        [TestMethod]
        public void AddScooter_AddScooterWithNegativePrice_ThrowsNegativePriceException()
        {
            Action act = () =>
                _scooterService.AddScooter("1",-0.2m);

            act.Should().Throw<InvalidPriceException>()
                .WithMessage("Given price -0,2 is not valid");
        }

        [TestMethod]
        public void AddScooter_AddScooterNullOrEmptyID_ThrowsInvalidIdException()
        {
            Action act = () =>
                _scooterService.AddScooter("",0.2m);

            act.Should().Throw<InvalidIdException>()
                .WithMessage("ID cannot be Null or Empty");
        }


    }
}
