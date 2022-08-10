using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1
{
    class Product
    {
        private string name;
        private double price;
        private int amount;

        public Product(string productName, double priceAtStart, int amountAtStart)
        {
            name = productName;
            price = priceAtStart;
            amount = amountAtStart;
        }

        public void SetPrice(double newPrice)
        {
            price = newPrice;
        }

        public void SetAmount(int newAmount)
        {
            amount = newAmount;
        }

        public void PrintProduct()
        {
            Console.WriteLine($"{name}, price {price:0.00}, amount {amount}");
        }
    }
}
