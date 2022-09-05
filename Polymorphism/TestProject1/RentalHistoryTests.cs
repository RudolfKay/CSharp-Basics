using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ScooterRental.Exceptions;
using FluentAssertions;
using System;
using ScooterRental.Interfaces;

namespace ScooterRental.Tests
{
    [TestClass]
    public class RentalHistoryTests
    {
        private ScooterService _scooterService;
        private List<Scooter> _inventory;
        private RentalHistory _rentalHistory;
        private List<RentedScooter> _rentedInventory;
        private RentalCompany _rentalCompany;

        [TestInitialize]
        public void Setup()
        {
            _inventory = new List<Scooter>();
            _rentedInventory = new List<RentedScooter>();
            _scooterService = new ScooterService(_inventory);

            for (int i = 1; i <= 5; i++)
            {
                _scooterService.AddScooter($"{i}", 0.2m);
            }
            
            _rentalCompany = new RentalCompany("Cheeki Breeki", _rentedInventory, _scooterService);
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
            Scooter scooter = _scooterService.GetScooterById("2");

            Action act = () =>
                _rentalHistory.AddIncome(scooter, 0, 2.5m);

            act.Should().Throw<YearNotValidException>()
                .WithMessage("Year is not in records");
        }

        [TestMethod]
        public void AddIncome_AddIncomeWithInvalidScooter_ThrowsScooterDoesNotExistException()
        {
            Scooter scooter = new Scooter("8", 0.2m);

            Action act = () =>
                _rentalHistory.AddIncome(scooter, 2010, 2.5m);

            act.Should().Throw<ScooterDoesNotExistException>()
                .WithMessage("Scooter with ID 8 does not exist.");
        }

        [TestMethod]
        public void AddIncome_AddIncomeWithNullScooter_ThrowsNullScooterException()
        {
            Scooter scooter = null;

            Action act = () =>
                _rentalHistory.AddIncome(scooter, 2010, 2.5m);

            act.Should().Throw<NullScooterException>()
                .WithMessage("Scooter is Null");
        }

        [TestMethod]
        public void AddIncome_AddInvalidIncomeAmount_ThrowsInvalidIncomeException()
        {
            Scooter scooter = _scooterService.GetScooterById("1");

            Action act = () =>
                _rentalHistory.AddIncome(scooter, 2010, -0.2m);

            act.Should().Throw<InvalidIncomeException>()
                .WithMessage("Income amount is not valid");
        }

        [TestMethod]
        public void GetHistory_AddValidScootersWithoutYear_HistoryIsCorrect()
        {
            _rentalCompany.StartRent("1");
            _rentalCompany.StartRent("2");
            _rentalCompany.StartRent("3");
            _rentalCompany.EndRent("1");
            _rentalCompany.EndRent("2");
            _rentalCompany.EndRent("3");

            var history = _rentalHistory.GetHistory(null);

            history.Count.Should().Be(5);
        }

        [TestMethod]
        public void GetHistory_AddValidScootersWithYear_HistoryIsCorrect()
        {
            _rentalCompany.StartRent("1");
            _rentalCompany.StartRent("2");
            _rentalCompany.StartRent("3");
            _rentalCompany.EndRent("1");
            _rentalCompany.EndRent("2");
            _rentalCompany.EndRent("3");

            var history = _rentalHistory.GetHistory(2022);

            history.Count.Should().Be(3);
        }
    }
}
