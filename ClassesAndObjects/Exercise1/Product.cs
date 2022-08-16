using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1
{
    class Product
    {
        private string _name;
        private double _price;
        private int _amount;

        public Product(string productName, double priceAtStart, int amountAtStart)
        {
            _name = productName;
            _price = priceAtStart;
            _amount = amountAtStart;
        }

        public void SetPrice(double newPrice)
        {
            _price = newPrice;
        }

        public void SetAmount(int newAmount)
        {
            _amount = newAmount;
        }

        public void PrintProduct()
        {
            Console.WriteLine($"{_name}, Price: {_price:0.00}, Amount: {_amount}");
        }
    }
}
