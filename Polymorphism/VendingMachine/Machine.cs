using System;
using System.Collections.Generic;
using System.Linq;
using VendingMachine.Exceptions;
using VendingMachine.Interfaces;

namespace VendingMachine
{
    public class Machine : IVendingMachine
    {
        public string Manufacturer { get; }
        public Money Amount { get; set; }
        public Product[] Products { get; set; }

        public bool HasProducts => Products != null;

        public Machine(string manufacturer, int productSpace)
        {
            if (string.IsNullOrEmpty(manufacturer))
            {
                throw new InvalidManufacturerException();
            }

            if (productSpace <= 0)
            {
                throw new InvalidVendingSlotCountException();
            }

            Amount = new Money(0,0);
            Manufacturer = manufacturer;
            Products = new Product[productSpace];
        }

        public Money InsertCoin(Money amount)
        {
            if (amount.GetTotalCents() <= 0)
            {
                throw new InvalidMoneyException();
            }

            int[] acceptedCurrency = { 10, 20, 50, 100, 200 };

            if (acceptedCurrency.Contains(amount.GetTotalCents()))
            {
                Console.WriteLine("*clink* Accepted.");
                Amount = new Money(Amount.GetTotalCents() + amount.GetTotalCents());

                return Amount;
            }
            
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
            if (string.IsNullOrEmpty(name))
            {
                throw new InvalidNameException();
            }

            if (price.GetTotalCents() <= 0)
            {
                throw new InvalidMoneyException();
            }

            if (count <= 0)
            {
                throw new InvalidProductCountException();
            }

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
                    if (Products[i].Equals(null))
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
            if (productNumber < 0)
            {
                throw new InvalidSelectionException();
            }

            if (string.IsNullOrEmpty(name))
            {
                throw new InvalidNameException();
            }

            if (price.GetTotalCents() <= 0)
            {
                throw new InvalidMoneyException();
            }

            if (amount < 0)
            {
                throw new InvalidProductCountException();
            }

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
            Console.WriteLine($"\nManufactured by {Manufacturer}.");

            if (Products.Length <= 0)
            {
                throw new MachineIsEmptyException();
            }

            foreach (Product product in Products)
            {
                Console.WriteLine($"{Array.IndexOf(Products, product)} - {product.ToString()}");
            }

            Console.WriteLine();
        }
    }
}
