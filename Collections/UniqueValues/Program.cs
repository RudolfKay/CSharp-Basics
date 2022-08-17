using System;
using System.Linq;
using System.Collections.Generic;

namespace UniqueValues
{
    class Program
    {
        static void Main(string[] args)
        {
            //ToDo: Given a non-empty list of strings, return a list that contains only unique (non-duplicate) strings.
            //ToDo: Example: ["abc", "xyz", "klm", "xyz", "abc", "abc", "rst"] → ["klm", "rst"]

            var values = new List<string> { "Hi", "Meow", "Hello", "Meow", "Hi!", "Meow", "Hi", "Bye" };

            var uniqueValQuery = 
                (from value in values
                    select value).ToHashSet();
            
            Console.WriteLine(string.Join(", ",uniqueValQuery));
            Console.ReadKey();
        }
    }
}
