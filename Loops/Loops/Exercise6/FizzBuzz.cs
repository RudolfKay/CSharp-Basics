using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise6
{
    class FizzBuzz
    {
        static void Main(string[] args)
        {
            Console.Write("Max value? ");
            var input = int.Parse(Console.ReadLine());
            int lineLength = 20;

            for (int i = 1; i <= input; i++)
            {
                Console.Write(FizzOrBuzz(i)+" ");

                if (i % lineLength == 0)
                {
                    Console.WriteLine("\n");
                }
            }

            Console.ReadKey();
        }

        static string FizzOrBuzz(int number)
        {
            string result = number.ToString();

            if (number % 3 == 0)
            {
                result = "Fizz";

                if (number % 5 == 0)
                {
                    result += "Buzz";
                }
            }
            else if (number % 5 == 0)
            {
                result = "Buzz";
            }

            return result;
        }
    }
}
