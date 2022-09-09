using System;

namespace VendingMachine
{
    public class Runner
    {
        private static Machine _vendingMachine;

        public static void Main()
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
                int amountLeft = selection.Available;
                int cost = 0;

                while (cost < totalPrice && amountLeft > 0)
                {
                    Money startingMoney = _vendingMachine.Amount;

                    Console.WriteLine($"Please insert coins (Accepted: 10 20 50 100 200)");
                    Console.WriteLine($"Remaining amount: {totalPrice - cost}");
                    int cents = int.Parse(Console.ReadLine());

                    Money currentMoney = _vendingMachine.InsertCoin(new(cents));

                    if (currentMoney.GetTotalCents() > startingMoney.GetTotalCents())
                    {
                        cost += cents;
                    }

                    Console.ReadKey();
                    Console.Clear();
                }

                if (amountLeft == 0)
                {
                    Console.WriteLine($"{selection.Name} is out of stock...");
                }

                if (cost > totalPrice)
                {
                    int difference = cost - totalPrice;
                    Console.WriteLine($"Dispensing change...*dink,dink,chink,dink*");
                    Console.WriteLine($"You find {difference} cents in the change slot.\n");

                    _vendingMachine.Amount = new(_vendingMachine.Amount.GetTotalCents() - difference);
                    cost = totalPrice;
                }
                if (cost == totalPrice)
                {
                    Console.WriteLine($"Dispensing item...*brrrrrrrt*...*clink*");
                    _vendingMachine.UpdateProduct(int.Parse(userInput), selection.Name, selection.Price, amountLeft - 1);
                }

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

            Product p0 = new("Fanta",new Money(90),1);
            Product p1 = new("Sprite", new Money(90), 5);
            Product p2 = new("Coca-Cola", new Money(100), 5);
            Product p3 = new("Pepsi", new Money(100), 5);
            Product p4 = new("Orbit", new Money(70), 5);
            Product p5 = new("Dirol", new Money(60), 5);
            Product p6 = new("Lays", new Money(150), 5);
            Product p7 = new("Estrella", new Money(170), 5);
            Product p8 = new("Cheetos", new Money(140), 5);
            Product p9 = new("Snickers", new Money(120), 5);

            _vendingMachine.Products = new[] { p0, p1, p2, p3, p4, p5, p6, p7, p8, p9 };
        }
    }
}
