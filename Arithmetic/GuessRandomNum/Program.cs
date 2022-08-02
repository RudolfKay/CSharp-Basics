using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessRandomNum
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            const int lowerBound = 1;
            const int upperBound = 100;
            int target = r.Next(lowerBound, upperBound);

            Console.WriteLine(target);

            Console.WriteLine("Ready to guess the number? You get 3 tries!\nPick an integer from 1 to 100...");
            string userInput = Console.ReadLine();
            int intCheck = 0;

            while (string.IsNullOrEmpty(userInput) || !Int32.TryParse(userInput, out intCheck))
            {
                Console.WriteLine("Input is invalid! Has to be an integer. Enter your guess: ");
                userInput = Console.ReadLine();
            }

            for (int threeTries = 0; threeTries <= 2; threeTries++)
            {
                if (threeTries == 2)
                {
                    Console.WriteLine("That was your last try, sorry!\nBetter luck next time.");
                    break;
                }

                int guess = Int32.Parse(userInput);

                switch (guess == target)
                {
                    case true:
                        Console.WriteLine("Great guess! You got it!");
                        break;

                    case false:
                        if (guess > target)
                        {
                            Console.WriteLine("Sorry, too HIGH.\nGuess again:");
                            userInput = Console.ReadLine();
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("Sorry, too LOW.\nGuess again:");
                            userInput = Console.ReadLine();
                            continue;
                        }
                }

                break;
            }

            Console.ReadKey();
        }
    }
}
