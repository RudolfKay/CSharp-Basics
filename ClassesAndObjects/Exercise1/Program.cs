using System;

namespace Exercise1
{
    class Program
    {
        public static void Main(string[] args)
        {
            string name1 = "Logitech mouse";
            double price1 = 70.00;
            int amount1 = 14;
            Product product1 = new Product(name1, price1, amount1);

            string name2 = "iPhone 5s";
            double price2 = 999.99;
            int amount2 = 3;
            Product product2 = new Product(name2, price2, amount2);

            string name3 = "Epson EB-U05";
            double price3 = 440.46;
            int amount3 = 1;
            Product product3 = new Product(name3, price3, amount3);

            product1.PrintProduct();
            product2.PrintProduct();
            product3.PrintProduct();

            Console.ReadKey();
        }
    }
}
