using System;
using System.Collections.Generic;

namespace Exercise4
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<String> nameSet = new HashSet<String>();

            string input = "";

            while (nameSet.Count == 0 || !input.Trim().Equals(String.Empty))
            {
                Console.Write("Enter Name: ");
                input = Console.ReadLine();
                nameSet.Add(input);
            }

            Console.Write($"Unique name list contains: {string.Join(", ", nameSet).Trim(new char[] {',',' '})}.");
            Console.ReadKey();
        }
    }
}
