using System;

namespace GetTheCentury
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter year from 1000 to 2010...");
            string input = Console.ReadLine();

            int intCheck = 0;

            while (!int.TryParse(input, out intCheck) || int.Parse(input) < 1000 || int.Parse(input) > 2010)
            {
                Console.WriteLine("ERROR: Input not a year within range.\nEnter year from 1000 to 2010:");
                input = Console.ReadLine();
            }

            Console.WriteLine(Century(int.Parse(input)));
            Console.ReadKey();
        }

        public static string Century(int year)
        {
            if (year > 2000) return $"{(year / 100 + 1).ToString()}st Century";

            else if (year % 10 > 0) return $"{(year / 100 + 1).ToString()}th Century";
            
            else if (year % 10 == 0) return $"{(year / 100).ToString()}th Century";

            else return "404: Century not found.";
        }
    }
}
