using System;

namespace Exercise9
{
    class RollTwoDice
    {
        static void Main(string[] args)
        {
            int sideCount = 6; //Number of sides a single die has
            RollIt(sideCount);
        }

        static void RollIt(int sideCount)
        {
            Random random = new Random();

            Console.WriteLine($"What sum are you looking for? ");
            int sum = Convert.ToInt32(Console.ReadLine());

            Console.Clear();
            Console.WriteLine($"Desired sum: {sum}");

            int currentDiceSum = 0;

            while (currentDiceSum != sum)
            {
                int die1 = random.Next(1, sideCount + 1);
                int die2 = random.Next(1, sideCount + 1);

                currentDiceSum = die1 + die2;
                Console.WriteLine($"{die1} and {die2} = {currentDiceSum}");
            }

            Console.ReadKey();
        }
    }
}
