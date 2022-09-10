using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachine.Exceptions;
using FluentAssertions;
using System;

namespace VendingMachine.Tests
{
    [TestClass]
    public class MoneyTests
    {
        [TestMethod]
        public void Money_InitializeNewMoney_AmountIsCorrect()
        {
            Money money1 = new Money(2, 50);
            Money money2 = new Money(250);

            money1.Euros.Should().Be(2);
            money1.Cents.Should().Be(50);
            money1.GetTotalCents().Should().Be(250);
            money2.Euros.Should().Be(2);
            money2.Cents.Should().Be(50);
            money2.GetTotalCents().Should().Be(250);
        }

        [TestMethod]
        public void Money_InitializeNewMoneyWithNegativeAmount_ThrowsInvalidAmountException()
        {
            Action act1 = () => 
                new Money(-2, -50);
            Action act2 = () =>
                new Money(2, -50);
            Action act3 = () =>
                new Money(-250);

            act1.Should().Throw<InvalidAmountException>().
                WithMessage("Amount is below zero");
            act2.Should().Throw<InvalidAmountException>().
                WithMessage("Amount is below zero");
            act3.Should().Throw<InvalidAmountException>().
                WithMessage("Amount is below zero");
        }

        [TestMethod]
        public void Money_GetMoneyToString_StringFormatIsCorrect()
        {
            var money = new Money(2, 50);

            Action act1 = () => 
                money.ToString();

            act1.Equals($"{money.Euros},{money.Cents:00}Eur");
        }
    }
}
