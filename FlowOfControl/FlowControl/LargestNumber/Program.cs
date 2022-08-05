using System;
using System.Linq;

namespace LargestNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int intCheck = 0;
            int largest = 0;
            var input1 = "";
            var input2 = "";
            var input3 = "";

            while (!int.TryParse(input1, out intCheck) || !int.TryParse(input2, out intCheck) || !int.TryParse(input3, out intCheck))
            {
                int cycleCount = 1;

                if (cycleCount != 1)
                {
                    Console.WriteLine("ERROR: One or more inputs invalid! Try again...");
                }

                Console.WriteLine("Input the 1st number: ");
                input1 = Console.ReadLine();

                Console.WriteLine("Input the 2nd number: ");
                input2 = Console.ReadLine();

                Console.WriteLine("Input the 3rd number: ");
                input3 = Console.ReadLine();

                cycleCount += 1;
            }

            int[] inputArray = {int.Parse(input1), int.Parse(input2), int.Parse(input3)};

            largest = inputArray.Max();
            Console.WriteLine($"Largest of the three numbers is {largest}");
            Console.ReadKey();
        }
    }
}
