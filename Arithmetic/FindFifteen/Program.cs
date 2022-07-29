using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindFifteen
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter two numbers when prompted. If True - there's a fifteen there!");

            Console.WriteLine("1st Number:");
            string firstInt = Console.ReadLine();

            Console.WriteLine("2nd Number:");
            string secondInt = Console.ReadLine();

            int intCheck = 0;

            while (!Int32.TryParse(firstInt,out intCheck) || !Int32.TryParse(secondInt,out intCheck))
            {
                Console.WriteLine("Input invalid! Try again.");

                Console.WriteLine("1st Number:");
                firstInt = Console.ReadLine();

                Console.WriteLine("2nd Number:");
                secondInt = Console.ReadLine();
            }

            Console.WriteLine(FindFifteen(Convert.ToInt32(firstInt), Convert.ToInt32(secondInt)));
            Console.ReadKey();
        }

        static bool FindFifteen(int firstInt, int secondInt)
        {
            Console.WriteLine("Checking for 15...");
            if (firstInt == 15 || secondInt == 15 || Math.Abs(firstInt - secondInt) == 15 || firstInt + secondInt == 15)
            {
                return true;
            }

            return false;
        }
    }
}
