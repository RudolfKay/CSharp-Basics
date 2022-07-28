using System;

namespace NameAndBirthYear
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter your year of birth: ");
            int birthYear = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"My name is {name} and I was born in {birthYear}.");
            Console.ReadKey();
        }
    }
}
