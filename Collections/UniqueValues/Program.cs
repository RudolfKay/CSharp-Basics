using System;
using System.Linq;
using System.Collections.Generic;

namespace UniqueValues
{
    class Program
    {
        static void Main(string[] args)
        {
            var values = new List<string> { "Hi", "Meow", "Hello", "Meow", "Hi!", "Meow", "Hi", "Bye" };

            var uniqueValQuery = 
                (from value in values
                    select value).ToHashSet();
            
            Console.WriteLine(string.Join(", ",uniqueValQuery));
            Console.ReadKey();
        }
    }
}
