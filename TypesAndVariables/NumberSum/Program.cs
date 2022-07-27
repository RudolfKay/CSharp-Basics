using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberSum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello! This program finds the sum of selected single digits...");
            Console.WriteLine("What digits would you like the sum of?");

            string userInput = Console.ReadLine();
            int sum = 0;
            int intCheck = 0;

            while (string.IsNullOrEmpty(userInput) || !int.TryParse(userInput, out intCheck))
            {
                Console.WriteLine("Input is invalid! Please try again.");
                Console.WriteLine("Which digits would you like the sum of?");
                userInput = Console.ReadLine();
            }

            foreach (char c in userInput)
            {
                sum += int.Parse(c.ToString());
            }

            Console.WriteLine($"Sum of {userInput} is {sum}");
            Console.ReadKey();
        }
    }
}
