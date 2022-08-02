using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product1ToN
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter upper bound number:");
            string input = Console.ReadLine();
            int product = 1;
            int intCheck = 0;

            while (string.IsNullOrEmpty(input) || !Int32.TryParse(input,out intCheck))
            {
                Console.WriteLine("Input is invalid! Has to be an integer. Try again: ");
                input = Console.ReadLine();
            }

            int inputInt = Convert.ToInt32(input);

            for (int i = 2; i <= inputInt; i++)
            {
                product *= i;
            }

            Console.WriteLine($"Product of numbers in range 1 to {inputInt} is {product}");
            Console.ReadKey();
        }
    }
}
