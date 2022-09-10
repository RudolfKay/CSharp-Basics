using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachine.Exceptions;
using FluentAssertions;
using System;

namespace VendingMachine.Tests
{
    [TestClass]
    public class ProductTest
    {
        [TestMethod]
        public void Product_InitializeNewProduct_ProductInitSuccess()
        {
            Product product = new Product("Behringer", new Money(2,50), 5);

            product.Name.Should().Be("Behringer");
            product.Price.Euros.Should().Be(2);
            product.Price.Cents.Should().Be(50);
            product.Available.Should().Be(5);
        }

        [TestMethod]
        public void Product_InitializeProductWithInvalidName_ThrowsInvalidNameException()
        {
            Action act1 = () =>
                new Product("", new Money(2, 50), 5);

            act1.Should().Throw<InvalidNameException>().
                WithMessage("Product name is invalid");
        }

        [TestMethod]
        public void Product_InitializeProductWithInvalidPrice_ThrowsInvalidMoneyException()
        {
            Action act1 = () =>
                new Product("Name", new Money(0), 5);

            act1.Should().Throw<InvalidMoneyException>().
                WithMessage("Price is invalid");
        }

        [TestMethod]
        public void Product_InitializeProductWithInvalidProductCount_ThrowsInvalidProductCountException()
        {
            Action act1 = () =>
                new Product("Name", new Money(2, 50), -5);

            act1.Should().Throw<InvalidProductCountException>().
                WithMessage("Cannot add product with invalid count");
        }

        [TestMethod]
        public void Product_GetProductToString_StringFormatIsCorrect()
        {
            var product = new Product("Name", new Money(250), 5);

            Action act1 = () =>
            product.ToString();

            act1.Equals($"{product.Name}: {product.Price.ToString()}, Amount: {product.Available}");
        }
    }
}
