using System;
using System.Linq;

namespace ReplaceSubstring
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = new[] { "near", "speak", "tonight", "weapon", "customer", "deal", "lawyer" };

            var wordQuery =
                (from word in words
                    where word.Contains("ea")
                    select word);

            foreach (string word in wordQuery)
            {
                int indexOfWord = Array.IndexOf(words, word);
                words.SetValue(word.Replace("ea","*"),indexOfWord);
            }

            Console.WriteLine(string.Join(", ", words));
            Console.ReadKey();
        }
    }
}
