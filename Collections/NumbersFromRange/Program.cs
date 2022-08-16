using System;
using System.Collections.Generic;
using System.Linq;

namespace NumbersFromRange
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            var numbers = new List<int>();

            while (numbers.Count() < 10)
            {
                numbers.Add(random.Next(1, 100));
            }

            var greaterLesserQuery = 
                    (from num in numbers
                    where num is < 100 and > 30
                    select num).ToList();

            Console.WriteLine(string.Join(", ",greaterLesserQuery));
            Console.ReadKey();
        }
    }
}
