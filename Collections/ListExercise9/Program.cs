using System;
using System.Collections.Generic;

namespace ListExercise9
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstList = new List<string>
            {
                "Red",
                "Green",
                "Black",
                "White",
                "Pink"
            };

            Console.WriteLine(string.Join(",", firstList) + "\n");

            var secondList = new List<string>
            {
                "Red",
                "Green",
                "Black",
                "White",
                "Pink"
            };

            Console.WriteLine(string.Join(",", secondList) + "\n");
            
            firstList.AddRange(secondList);

            Console.WriteLine("Outcome of joining the 1st and 2nd lists:");
            Console.WriteLine(string.Join(",", firstList));

            Console.ReadKey();
        }
    }
}
