using System;

namespace Exercise5
{
    class Program
    {
        static void Main(string[] args)
        {
            int lineLength = 30;

            Console.WriteLine("Choose 1st word: ");
            string wordOne = Console.ReadLine();
            Console.WriteLine("Choose 2nd word: ");
            string wordTwo = Console.ReadLine();

            string separator = "";
            int separatorLength = lineLength - wordOne.Length - wordTwo.Length;

            for (int i = 0; i < separatorLength; i++)
            {
                separator += ".";
            }

            Console.WriteLine($"{wordOne}{separator}{wordTwo}");
            Console.ReadKey();
        }
    }
}
