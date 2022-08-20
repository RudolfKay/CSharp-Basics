using System;
using System.Collections.Generic;

namespace ListExercise11
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> stringList = new List<string>();
            
            stringList.AddRange(new string[] {"a","b","c","d","e","f","g","h","i","j"});
            
            stringList.Insert(4,"X");
            
            stringList.RemoveAt(stringList.Count-1);
            stringList.Add("O");
            
            stringList.Sort();
            
            Console.WriteLine(stringList.Contains("Foobar"));
            
            foreach (string s in stringList)
            {
                Console.WriteLine(s);
            }

            Console.ReadKey();
        }
    }
}
