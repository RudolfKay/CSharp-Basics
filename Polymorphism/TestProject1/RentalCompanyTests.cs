using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ScooterRental.Exceptions;
using FluentAssertions;
using System;
using ScooterRental.Interfaces;

namespace ScooterRental.Tests
{
    [TestClass]
    public class RentalCompanyTests
    {
        private ScooterService _scooterService;
        private RentalCompany _rentalCompany;
        private List<Scooter> _inventory;
        private List<RentedScooter> _rentedInventory;

        [TestInitialize]
        public void Setup()
        {
            _inventory = new List<Scooter>();
            _rentedInventory = new List<RentedScooter>();
            _scooterService = new ScooterService(_inventory);

            for (int i = 0; i < 5; i++)
            {
                _scooterService.AddScooter($"{i}",0.2m);
            }

            _rentalCompany = new RentalCompany("Cheeki Breeki", _rentedInventory, _scooterService);
        }

        [TestMethod]
        public void StartRent_StartRentingScooter_ScooterIsRented()
        {
            _rentalCompany.StartRent("2");
            _scooterService.GetScooterById("2").IsRented.Should().BeTrue();
        }

        [TestMethod]
        public void StartRent_NullOrEmptyIdGiven_ThrowsInvalidIdException()
        {
            Action act = () =>
                _rentalCompany.StartRent("");

            act.Should().Throw<InvalidIdException>()
                .WithMessage("ID cannot be Null or Empty");
        }

        [TestMethod]
        public void StartRent_ScooterDoesNotExist_ThrowsScooterDoesNotExistException()
        {
            Action act = () =>
                _rentalCompany.StartRent("9");

            act.Should().Throw<ScooterDoesNotExistException>()
                .WithMessage("Scooter with ID 9 does not exist.");
        }

        [TestMethod]
        public void EndRent_EndRentingScooter_ScooterIsNotRented()
        {
            var scooter = _scooterService.GetScooterById("2");
            var rentedScooter = new RentedScooter("2", 0.2m, DateTime.UtcNow);

            scooter.IsRented = true;
            _rentedInventory.Add(rentedScooter);
            _rentalCompany.EndRent("2");

            scooter.IsRented.Should().BeFalse();
            rentedScooter.EndTime.HasValue.Should().BeTrue();
        }
        
        [TestMethod]
        public void EndRent_NullOrEmptyIdGiven_ThrowsInvalidIdException()
        {
            Action act = () =>
                _rentalCompany.EndRent("");

            act.Should().Throw<InvalidIdException>()
                .WithMessage("ID cannot be Null or Empty");
        }

        [TestMethod]
        public void EndRent_ScooterDoesNotExist_ThrowsScooterDoesNotExistException()
        {
            Action act = () =>
                _rentalCompany.EndRent("9");

            act.Should().Throw<ScooterDoesNotExistException>()
                .WithMessage("Scooter with ID 9 does not exist.");
        }

        [TestMethod]
        public void GetFee_FeeHasReachedDailyMax()
        {
            _rentalCompany.StartRent("1");
            RentedScooter rentedScoot = _rentedInventory[0];
            rentedScoot.StarTime = new DateTime(2022,09,03,20,00,00);
            rentedScoot.EndTime = new DateTime(2022, 09, 04, 00, 00, 00);

            TimeSpan rentTime = (DateTime)rentedScoot.EndTime - rentedScoot.StarTime;
            decimal result = _rentalCompany.GetFee(rentTime, rentedScoot.PricePerMinute);

            rentTime.TotalMinutes.Should().Be(240);
            result.Should().Be(20.0m);
        }

        [TestMethod]
        public void GetFee_FeeJustBelowDailyMax()
        {
            _rentalCompany.StartRent("1");
            RentedScooter rentedScoot = _rentedInventory[0];
            rentedScoot.StarTime = new DateTime(2022,09,03,20,00,00);
            rentedScoot.EndTime = new DateTime(2022, 09, 03, 21, 39, 00);

            TimeSpan rentTime = (DateTime)rentedScoot.EndTime - rentedScoot.StarTime;
            decimal result = _rentalCompany.GetFee(rentTime, rentedScoot.PricePerMinute);

            rentTime.TotalMinutes.Should().Be(99);
            result.Should().Be(19.8m);
        }

        [TestMethod]
        public void GetFee_ScooterRentedManyDays_FeeIsCorrect()
        {
            _rentalCompany.StartRent("1");
            RentedScooter rentedScoot = _rentedInventory[0];
            rentedScoot.StarTime = new DateTime(2022,09,03,20,00,00);
            rentedScoot.EndTime = new DateTime(2022, 09, 08, 01, 00, 00);

            TimeSpan rentTime = (DateTime)rentedScoot.EndTime - rentedScoot.StarTime;
            decimal result = _rentalCompany.GetFee(rentTime, rentedScoot.PricePerMinute);

            rentTime.TotalMinutes.Should().Be(6060);
            rentTime.Days.Should().Be(4);
            rentTime.Hours.Should().Be(5);
            result.Should().Be(112.0m); //80.0m is incorrect
        }
    }
}
