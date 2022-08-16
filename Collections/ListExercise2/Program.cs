using System;
using System.Collections.Generic;

namespace ListExercise2
{
    class Program
    {
        private static void Main(string[] args)
        {
            var colors = new List<string>();

            colors.Add("Red");
            colors.Add("Green");
            colors.Add("Orange");
            colors.Add("White");
            colors.Add("Black");

            PrintList(colors);

            Console.ReadKey();
        }

        private static void PrintList(List<string> colors)
        {
            foreach (string element in colors)
            {
                Console.WriteLine(element);
            }
        }
    }
}
