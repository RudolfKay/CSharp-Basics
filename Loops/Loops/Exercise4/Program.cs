using System;

namespace Exercise4
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };

            for (int i = 0; i < vowels.Length; i++)
            {
                Console.WriteLine(vowels[i]);
            }
            
            foreach (char vowel in vowels)
            {
                Console.WriteLine(vowel);
            }

            Console.ReadKey();
        }
    }
}
