using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FindUpperCase
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter string using upper and lower case letters:");
            string userInput = Console.ReadLine();
            string onlyUpperCase = "";

            while (string.IsNullOrEmpty(userInput))
            {
                Console.WriteLine("ERROR: Input is empty, try again!");
                Console.WriteLine("Please enter string:");
                userInput = Console.ReadLine();
            }
            Console.WriteLine($"Checking string...");

            /*foreach (char c in userInput)
            {
                if (char.IsLetter(c))
                {
                    string thisChar = c.ToString();

                    if (thisChar.Equals(thisChar.ToUpper()))
                    {
                        upperCaseCount += 1;
                    }
                }
            }*/
            onlyUpperCase = Regex.Replace(userInput,"([^A-Z])", "");

            Console.WriteLine($"Number of upper case letters found: {onlyUpperCase.Length}.");
            Console.ReadKey();
        }
    }
}
