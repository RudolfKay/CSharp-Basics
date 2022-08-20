using System;
using System.Collections.Generic;

namespace Exercise10
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> set = new HashSet<string>(){"one","two","three","four","five"};

            foreach (string item in set)
            {
                Console.WriteLine(item);
            }

            set.Clear();
            Console.WriteLine(string.Join(" ", set));

            set.Add("Can you");
            set.Add("add duplicates");
            set.Add("add duplicates");
            set.Add("to a HashSet?");
            set.Add("No.");
            set.Add("No.");
            set.Add("No you cannot.");

            Console.WriteLine(string.Join(" ",set));

            Console.ReadKey();
        }
    }
}
