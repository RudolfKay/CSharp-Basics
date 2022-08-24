using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class Runner
    {
        private static Machine _vendingMachine;

        public static void Main(string[] args)
        {
            RestockMachine();

            Console.WriteLine("Press x: Check available items.\nPress q: Quit.");
            var userInput = Console.ReadLine();

            while (userInput != "q")
            {
                Product[] stock = _vendingMachine.Products;
                _vendingMachine.DisplayItems();

                Console.WriteLine("Select your item by number press q to Quit...");
                userInput = Console.ReadLine();

                if (userInput.Equals("q"))
                {
                    break;
                }

                Product selection = stock[int.Parse(userInput)];

                Console.WriteLine($"\nYour Selection:\n{Array.IndexOf(stock,selection)} - {selection.ToString()}");
                int totalPrice = selection.Price.GetTotalCents();
                int cost = 0;

                while (cost < totalPrice)
                {
                    Console.WriteLine($"Please insert coins (Accepted: 0,10 0,20 0,50 1,00 2,00)");
                    Console.WriteLine($"Remaining amount: {totalPrice - cost}");
                    int cents = int.Parse(Console.ReadLine());

                    cost += cents;

                    Console.ReadKey();
                    Console.Clear();
                }

                if (cost > totalPrice)
                {
                    int difference = cost - totalPrice;
                    Console.WriteLine($"Dispensing change...*dink,dink,chink,dink*");
                    Console.WriteLine($"You find {difference} cents in the change slot.\n");
                    _vendingMachine.Amount = new Money(_vendingMachine.Amount.GetTotalCents() - difference);
                }

                Console.WriteLine($"Dispensing item...*brrrrrrrt*...*clink*");
                _vendingMachine.UpdateProduct(int.Parse(userInput), selection.Name, selection.Price, selection.Available - 1);

                Console.ReadKey();
                Console.Clear();

                Console.WriteLine("Press x: Buy something else.\nPress q: Walk away.");
                userInput = Console.ReadLine();
            }

            Console.ReadKey();
        }

        public static void RestockMachine()
        {
            _vendingMachine = new Machine("Nippon", 20);

            Product p0 = new Product("Fanta",new Money(90),5);
            Product p1 = new Product("Sprite", new Money(90), 5);
            Product p2 = new Product("Coca-Cola", new Money(100), 5);
            Product p3 = new Product("Pepsi", new Money(100), 5);
            Product p4 = new Product("Orbit", new Money(70), 5);
            Product p5 = new Product("Dirol", new Money(60), 5);
            Product p6 = new Product("Lays", new Money(150), 5);
            Product p7 = new Product("Estrella", new Money(170), 5);
            Product p8 = new Product("Cheetos", new Money(140), 5);
            Product p9 = new Product("Snickers", new Money(120), 5);

            _vendingMachine.Products = new[] { p0, p1, p2, p3, p4, p5, p6, p7, p8, p9 };
        }
    }
}
