using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScooterRental.Exceptions;
using System;
using System.Collections.Generic;

namespace ScooterRental.Tests
{
    [TestClass]
    public class RentalCompanyTests
    {
        private ScooterService _scooterService;
        private RentalCompany _rentalCompany;
        private List<Scooter> _inventory;
        private List<RentedScooter> _rentedInventory;
        private RentalHistory _rentalHistory;
        private RentalCalculator _rentalCalculator;

        /*//Mocker
        private AutoMocker _mocker;
        private IRentalCompany _company;
        private Mock<IScooterService> _scooterServiceMock;
        private Scooter _defaultScooter;*/

        [TestInitialize]
        public void Setup()
        {
            /*//Mocker
            _defaultScooter = new Scooter("1", 0.2m);
            _mocker = new AutoMocker();
            _scooterServiceMock = _mocker.GetMock<IScooterService>();
            _company = new RentalCompany("Insurance", _rentedInventory, _scooterServiceMock.Object);*/

            _inventory = new List<Scooter>();
            _rentedInventory = new List<RentedScooter>();
            _rentalHistory = new RentalHistory(_rentedInventory);
            _scooterService = new ScooterService(_inventory);
            _rentalCalculator = new RentalCalculator();

            for (int i = 0; i < 5; i++)
            {
                _scooterService.AddScooter($"{i}", 0.2m);
            }

            _rentalCompany = new RentalCompany("Cheeki Breeki", _rentalHistory, _scooterService, _rentalCalculator);
        }

        /*[TestMethod]
        public void StartRentTest()
        {
            _scooterServiceMock
                .Setup(s => s.GetScooterById("1"))
                .Returns(_defaultScooter);

            _company.StartRent("1");

            _defaultScooter.IsRented.Should().BeTrue();
        }*/

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
            rentedScoot.StarTime = new DateTime(2022, 09, 03, 20, 00, 00);
            rentedScoot.EndTime = new DateTime(2022, 09, 04, 00, 00, 00);

            TimeSpan rentTime = (DateTime)rentedScoot.EndTime - rentedScoot.StarTime;
            decimal result = _rentalCalculator.GetFee(rentedScoot);

            rentTime.TotalMinutes.Should().Be(240);
            result.Should().Be(20.0m);
        }

        [TestMethod]
        public void GetFee_FeeJustBelowDailyMax()
        {
            _rentalCompany.StartRent("1");
            RentedScooter rentedScoot = _rentedInventory[0];
            rentedScoot.StarTime = new DateTime(2022, 09, 03, 20, 00, 00);
            rentedScoot.EndTime = new DateTime(2022, 09, 03, 21, 39, 00);

            TimeSpan rentTime = (DateTime)rentedScoot.EndTime - rentedScoot.StarTime;
            decimal result = _rentalCalculator.GetFee(rentedScoot);

            rentTime.TotalMinutes.Should().Be(99);
            result.Should().Be(19.8m);
        }

        [TestMethod]
        public void GetFee_ScooterRentedManyDays_FeeIsCorrect()
        {
            _rentalCompany.StartRent("1");
            RentedScooter rentedScoot = _rentedInventory[0];
            rentedScoot.StarTime = new DateTime(2022, 09, 03, 20, 00, 00);
            rentedScoot.EndTime = new DateTime(2022, 09, 08, 01, 00, 00);

            TimeSpan rentTime = (DateTime)rentedScoot.EndTime - rentedScoot.StarTime;
            decimal result = _rentalCalculator.GetFee(rentedScoot);

            rentTime.TotalMinutes.Should().Be(6060);
            rentTime.Days.Should().Be(4);
            result.Should().Be(92.0m);
        }

        [TestMethod]
        public void CalculateIncome_YearIsNullIncompleteRentalsFalse_ReturnsTotalIncome()
        {
            _rentalCompany.StartRent("1");
            _rentalCompany.StartRent("2");
            _rentalCompany.StartRent("3");
            RentedScooter rentedScoot1 = _rentedInventory[0];
            RentedScooter rentedScoot2 = _rentedInventory[1];
            RentedScooter rentedScoot3 = _rentedInventory[2];
            rentedScoot1.StarTime = new DateTime(2020, 09, 03, 20, 00, 00);
            rentedScoot1.EndTime = new DateTime(2020, 09, 08, 01, 00, 00);
            rentedScoot2.StarTime = new DateTime(2022, 09, 03, 20, 00, 00);
            rentedScoot2.EndTime = new DateTime(2022, 09, 08, 01, 00, 00);
            rentedScoot3.StarTime = new DateTime(2020, 09, 03, 20, 00, 00);

            decimal fee1 = _rentalCalculator.GetFee(rentedScoot1);
            decimal fee2 = _rentalCalculator.GetFee(rentedScoot2);
            decimal nullYearIncome = _rentalCompany.CalculateIncome(null, false);

            fee1.Should().Be(92.0m);
            fee2.Should().Be(92.0m);
            nullYearIncome.Should().Be(184.0m);
        }

        [TestMethod]
        public void CalculateIncome_YearIsNullIncompleteRentalsTrue_ReturnsTotalIncome()
        {
            _rentalCompany.StartRent("1");
            _rentalCompany.StartRent("2");
            _rentalCompany.StartRent("3");
            RentedScooter rentedScoot1 = _rentedInventory[0];
            RentedScooter rentedScoot2 = _rentedInventory[1];
            RentedScooter rentedScoot3 = _rentedInventory[2];
            rentedScoot1.StarTime = new DateTime(2020, 09, 03, 20, 00, 00);
            rentedScoot1.EndTime = new DateTime(2020, 09, 08, 01, 00, 00);
            rentedScoot2.StarTime = new DateTime(2022, 09, 03, 20, 00, 00);
            rentedScoot2.EndTime = new DateTime(2022, 09, 08, 01, 00, 00);
            rentedScoot3.StarTime = new DateTime(2020, 09, 03, 20, 00, 00);

            decimal fee1 = _rentalCalculator.GetFee(rentedScoot1);
            decimal fee2 = _rentalCalculator.GetFee(rentedScoot2);
            decimal nullYearIncome = _rentalCompany.CalculateIncome(null, true);

            fee1.Should().Be(92.0m);
            fee2.Should().Be(92.0m);
            nullYearIncome.Should().BeGreaterThan(200.0m);
        }

        [TestMethod]
        public void CalculateIncome_YearIsNotNullIncompleteRentalsFalse_ReturnsIncomeForYear()
        {
            _rentalHistory.AddIncome(new Scooter("1", 0.2m), 2020, 92);
            _rentalHistory.AddIncome(new Scooter("2", 0.2m), 2020, 92);

            decimal yearIncome = _rentalCompany.CalculateIncome(2020, false);
            yearIncome.Should().Be(184.0m);
        }

        [TestMethod]
        public void CalculateIncome_YearIsNotNullIncompleteRentalsTrue_ReturnsIncomeForYear()
        {
            _rentalHistory.AddIncome(new Scooter("1", 0.2m), 2022, 80);
            _rentalHistory.AddIncome(new Scooter("2", 0.2m), 2022, 20);
            _rentedInventory.Add(new RentedScooter("3", 0.2m, DateTime.UtcNow.AddMinutes(-20)));
            
            decimal yearIncome = _rentalCompany.CalculateIncome(2022, true);
            
            yearIncome.Should().Be(104.0m);
            //yearIncome.Should().BeLessThan(184.0m);
        }
    }
}
