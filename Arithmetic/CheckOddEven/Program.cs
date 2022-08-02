using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOddEven
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter any number:");
            string userInput = Console.ReadLine(); ;
            int intCheck = 0;
            
            while (String.IsNullOrEmpty(userInput) || !Int32.TryParse(userInput,out intCheck))
            {
                Console.WriteLine("Input is empty or non-numeric! Try again.\nEnter any number:");
                userInput = Console.ReadLine();
            }

            if (Convert.ToInt32(userInput) % 2 != 0)
            {
                Console.WriteLine("Odd Number");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Even Number");
                Console.ReadKey();
            }

            Console.WriteLine("Bye!");
            Console.ReadKey();
        }
    }
}
