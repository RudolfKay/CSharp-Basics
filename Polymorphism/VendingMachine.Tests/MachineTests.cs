using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachine.Exceptions;
using FluentAssertions;
using System;
using VendingMachine.Interfaces;

namespace VendingMachine.Tests
{
    [TestClass]
    public class MachineTests
    {
        private Machine _vendingMachine;

        [TestInitialize]
        public void Setup()
        {
            _vendingMachine = new Machine("VendPro", 20);

            Product p0 = new("Fanta",new(90),1);
            Product p1 = new("Sprite", new(90), 5);
            Product p2 = new("Coca-Cola", new(100), 5);
            Product p3 = new("Pepsi", new(100), 5);
            Product p4 = new("Orbit", new(70), 5);
            Product p5 = new("Dirol", new(60), 5);
            Product p6 = new("Lays", new(150), 5);
            Product p7 = new("Estrella", new(170), 5);
            Product p8 = new("Cheetos", new(140), 5);
            Product p9 = new("Snickers", new(120), 5);

            _vendingMachine.Products = new[] { p0, p1, p2, p3, p4, p5, p6, p7, p8, p9 };
        }

        [TestMethod]
        public void VendingMachine_CreateMachineWithInvalidManufacturer_ThrowsInvalidManufacturerException()
        {
            Action act = () => 
                new Machine("",10);

            act.Should().Throw<InvalidManufacturerException>().
                WithMessage("Manufacturer is invalid");
        }

        [TestMethod]
        public void VendingMachine_CreateMachineWithInvalidSlotCount_ThrowsInvalidVendingSlotCountException()
        {
            Action act1 = () => 
                new Machine("Vend-O-Matic",0);
            Action act2 = () =>
                new Machine("BlackHole", -13);

            act1.Should().Throw<InvalidVendingSlotCountException>().
                WithMessage("Vending slot count is invalid");
            act2.Should().Throw<InvalidVendingSlotCountException>().
                WithMessage("Vending slot count is invalid");
        }

        [TestMethod]
        public void VendingMachine_SetupMachine_VendingMachineCorrectlyStocked()
        {
            _vendingMachine.Products.Length.Should().Be(10);
            _vendingMachine.Amount.GetTotalCents().Should().Be(0);
            _vendingMachine.HasProducts.Should().BeTrue();
            _vendingMachine.Manufacturer.Should().Be("VendPro");
            _vendingMachine.Products[0].Available.Should().Be(1);
            _vendingMachine.Products[9].Name.Should().Be("Snickers");
            _vendingMachine.Products[9].Price.GetTotalCents().Should().Be(120);
        }

        [TestMethod]
        public void InsertCoin_InsertImpossibleCoin_ThrowsInvalidMoneyException()
        {
            Money money1 = new Money(-10);
            Money money2 = new Money(0);
            Action act1 = () => _vendingMachine.InsertCoin(money1);
            Action act2 = () => _vendingMachine.InsertCoin(money2);

            act1.Should().Throw<InvalidMoneyException>()
                .WithMessage($"Price is invalid");
            act2.Should().Throw<InvalidMoneyException>()
                .WithMessage($"Price is invalid");
        }

        [TestMethod]
        public void InsertCoin_InsertValidCoin_CoinAccepted()
        {
            Money money = new Money(50);
            Money vendingIncome = _vendingMachine.InsertCoin(money);

            _vendingMachine.Amount.GetTotalCents().Should().Be(50);
            vendingIncome.GetTotalCents().Should().Be(50);
        }

        [TestMethod]
        public void InsertCoin_InsertInvalidCoin_CoinRejected()
        {
            Money money = new Money(500);
            Money vendingIncome = _vendingMachine.InsertCoin(money);

            _vendingMachine.Amount.GetTotalCents().Should().Be(0);
            vendingIncome.GetTotalCents().Should().Be(0);
        }

        [TestMethod]
        public void ReturnMoney_DifferentCoinsInserted_EmptiesCoinsFromMachineCorrectly()
        {
            _vendingMachine.InsertCoin(new Money(500));
            _vendingMachine.InsertCoin(new Money(50));
            _vendingMachine.InsertCoin(new Money(10));
            _vendingMachine.InsertCoin(new Money(75));

            Money profits = _vendingMachine.ReturnMoney();

            profits.GetTotalCents().Should().Be(60);
            _vendingMachine.Amount.GetTotalCents().Should().Be(0);
        }

        [TestMethod]
        public void AddProduct_AddProductWithInvalidName_ThrowsInvalidNameException()
        {
            Action act = () =>
                _vendingMachine.AddProduct("", new Money(100), 5);

            act.Should().Throw<InvalidNameException>()
                .WithMessage($"Product name is invalid");
        }

        [TestMethod]
        public void AddProduct_AddProductWithInvalidPrice_ThrowsInvalidMoneyException()
        {
            Action act1 = () =>
                _vendingMachine.AddProduct("Dr. Pepper", new Money(-50), 5);

            Action act2 = () =>
                _vendingMachine.AddProduct("Pringles", new Money(0), 5);

            act1.Should().Throw<InvalidMoneyException>()
                .WithMessage($"Price is invalid");
            act2.Should().Throw<InvalidMoneyException>()
                .WithMessage($"Price is invalid");
        }

        [TestMethod]
        public void AddProduct_AddProductWithInvalidProductAmount_ThrowsInvalidProductCountException()
        {
            Action act1 = () =>
                _vendingMachine.AddProduct("Pringles", new Money(100), -1);
            Action act2 = () =>
                _vendingMachine.AddProduct("Dr. Pepper", new Money(100), 0);

            act1.Should().Throw<InvalidProductCountException>()
                .WithMessage($"Cannot add product with invalid count");
            act2.Should().Throw<InvalidProductCountException>()
                .WithMessage($"Cannot add product with invalid count");
        }

        [TestMethod]
        public void UpdateProduct_InvalidSelection_ThrowsInvalidSelectionException()
        {
            Action act = () =>
                _vendingMachine.UpdateProduct(-1, "Fake", new Money(100), 4);

            act.Should().Throw<InvalidSelectionException>()
                .WithMessage($"Selected product number is invalid");
        }

        [TestMethod]
        public void DisplayItems_MachineIsEmpty_ThrowsMachineIsEmptyException()
        {
            _vendingMachine.Products = Array.Empty<Product>();

            Action act = () => _vendingMachine.DisplayItems();

            act.Should().Throw<MachineIsEmptyException>()
                .WithMessage($"Vending machine is empty");
        }
    }
}
