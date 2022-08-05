using System;

namespace PositiveNegativeNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number.");
            var input = Console.ReadLine();
            int intCheck = 0;

            while (!int.TryParse(input, out intCheck))
            {
                Console.WriteLine("ERROR: Input not a number. Enter number:");
                input = Console.ReadLine();
            }

            if (int.Parse(input) > 0)
            {
                Console.WriteLine("Number is positive");
            } 
            else if (int.Parse(input) < 0) 
            {
                Console.WriteLine("Number is negative");
            } 
            else 
            {
                Console.WriteLine("Number is zero");
            }

            Console.ReadKey();
        }
    }
}
