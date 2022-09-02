using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScooterRental.Exceptions;
using System;
using FluentAssertions;
using ScooterRental.Interfaces;
using System.Collections.Generic;

namespace ScooterRental.Tests
{
    [TestClass]
    public class RentalHistoryTests
    {
        private ScooterService _scooterService;
        private List<Scooter> _inventory;
        private RentalHistory _rentalHistory;
        //private RentalCompany _rentalCompany;
        private List<RentedScooter> _rentedInventory;

        [TestInitialize]
        public void Setup()
        {
            _inventory = new List<Scooter>();
            _rentedInventory = new List<RentedScooter>();
            _scooterService = new ScooterService(_inventory);
            //_rentalCompany = new RentalCompany("Cheeki Breeki", _rentedInventory, _scooterService);

            for (int i = 1; i <= 5; i++)
            {
                _scooterService.AddScooter($"{i}",0.2m);
            }

            _rentalHistory = new RentalHistory(_scooterService);
        }

        [TestMethod]
        public void RentalHistory_InitializeRentalHistory_RentalHistoryCreated()
        {
            _rentalHistory.GetHistory(null).Count.Should().BeGreaterThan(4);
        }

        [TestMethod]
        public void AddIncome_AddIncomeWithInvalidYear_ThrowsYearNotValidException()
        {
            //_rentalHistory.
            Scooter scooter = _scooterService.GetScooterById("2");

            Action act = () =>
                _rentalHistory.AddIncome(scooter,0,2.5m);

            act.Should().Throw<YearNotValidException>()
                .WithMessage("Year is not in records");
        }
    }
}
