using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Console = System.Console;


namespace FlightPlanner
{
    class Program
    {
        private const string Path = "../../flights.txt";

        private static void Main(string[] args)
        {
            var readText = File.ReadAllLines(Path);

            foreach (var s in readText)
            {
                Console.WriteLine(s);
            }

            Console.ReadKey();
        }
    }
}
