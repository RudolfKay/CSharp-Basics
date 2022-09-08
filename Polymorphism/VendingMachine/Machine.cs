using System;
using System.Collections.Generic;
using System.Linq;
using VendingMachine.Interfaces;

namespace VendingMachine
{
    class Machine : IVendingMachine
    {
        public string Manufacturer { get; }
        public Money Amount { get; set; }
        public Product[] Products { get; set; }

        public Machine(string manufacturer, int productSpace)
        {
            Amount = new Money(0,0);
            Manufacturer = manufacturer;
            Products = new Product[productSpace];
        }

        public bool HasProducts => Products != null;

        public Money InsertCoin(Money amount)
        {
            int[] acceptedCurrency = new int[] { 10, 20, 50, 100, 200 };

            if (acceptedCurrency.Contains(amount.GetTotalCents()))
            {
                Console.WriteLine("*clink* Accepted.");
                Amount = new Money(Amount.GetTotalCents() + amount.GetTotalCents());

                return Amount;
            }
            else
                Console.WriteLine("*beep* Coin wasn't accepted.");

            return Amount;
        }

        public Money ReturnMoney()
        {
            int cents = Amount.GetTotalCents();
            Amount = new Money(0);

            return new Money(cents);
        }

        public bool AddProduct(string name, Money price, int count)
        {
            Product newProduct = new Product(name, price, count);

            if (Products.Length == 0)
            {
                Products[0] = newProduct;
            }
            else
            {
                for (int i = 0; i < Products.Length; i++)
                {
                    string prodName = Products[i].Name;
                    int prodCount = Products[i].Available;

                    if (prodName.Equals(name))
                    {
                        return UpdateProduct(i, name, price, count);
                    }
                    else if (Products[i].Equals(null))
                    {
                        Products[i] = newProduct;

                        return true;
                    }
                }
            }

            return false;
        }

        public bool UpdateProduct(int productNumber, string name, Money price, int amount)
        {
            if (!Products[productNumber].Equals(null))
            {
                Products[productNumber].Name = name;
                Products[productNumber].Price = price;
                Products[productNumber].Available = amount;

                return true;
            }

            return false;
        }

        public void DisplayItems()
        {
            Console.Clear();
            Console.WriteLine($"Manufactured by {Manufacturer}.");

            foreach (Product product in Products)
            {
                Console.WriteLine($"{Array.IndexOf(Products, product)} - {product.ToString()}");
            }

            Console.WriteLine();
        }
    }
}
