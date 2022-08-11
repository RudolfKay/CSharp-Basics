using System;

namespace Exercise7
{
    class Piglet
    {
        static void Main(string[] args)
        {
            PlayPiglet();
        }

        static void PlayPiglet()
        {
            Random random = new Random();
            bool endTrigger = new bool();
            int currentRoll = 0;
            int score = 0;

            Console.WriteLine("Welcome to Piglet!");

            while (!IsGameOver(currentRoll) && !endTrigger)
            {
                currentRoll = random.Next(1, 6);
                score += currentRoll;

                if (IsGameOver(currentRoll))
                {
                    score = 0;
                    Console.WriteLine($"You rolled a {currentRoll}!");
                    Console.WriteLine($"You got {score} points.");

                    break;
                }

                Console.WriteLine($"You rolled a {currentRoll}!");

                Console.Write("Roll again? ");
                string choice = Console.ReadLine();

                switch (choice.ToLower())
                {
                    default:
                        continue;

                    case "no":
                        Console.WriteLine($"You got {score} points.");
                        endTrigger = true;
                        break;
                }
            }

            Console.ReadKey();
        }

        static bool IsGameOver (int number)
        {
            return number == 1;
        }
    }
}
