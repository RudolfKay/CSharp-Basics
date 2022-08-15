using System;

namespace Exercise3
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int[] randomInts = new int[20];

            Console.WriteLine("There are 20 random numbers.\nWhat position are you looking for?\nEnter choice (0-19): ");
            int index = Convert.ToInt32(Console.ReadLine());
            
            for (int i = 0; i < randomInts.Length; i++)
            {
                randomInts[i] = random.Next();
            }

            Console.WriteLine($"Position {index} is {randomInts[index]}");
            Console.ReadKey();
        }
    }
}
