using System;
using System.IO;
using System.Linq;

namespace WordCount
{
    public class Program
    {
        static void Main(string[] args)
        {
            WordCount();
            Console.ReadKey();
        }

        public static void WordCount()
        {
            string fileText = File.ReadAllText("../../lear.txt");
            string wordFile = fileText.Replace("  ", " ");
            string charFile = fileText.Replace("\n","");
            int firstLine = 1;

            Console.WriteLine(fileText+"\n");

            var returnCount = 
                    (from c in fileText
                     where c.Equals('\n')
                     select c).ToList();

            var wordCount = 
                (from word in wordFile.Replace("\n"," ").Split(new []{' ','\''})
                    select GetWord(word)).ToList();

            var charCount = 
                (from c in charFile
                    select c).ToList();

            Console.WriteLine("Lines = " + (returnCount.Count+firstLine));
            Console.WriteLine("Words = " + wordCount.Count);
            Console.WriteLine("Chars = " + charCount.Count);
        }

        public static string GetWord(string s)
        {
            var word = 
                (from c in s
                 where char.IsLetterOrDigit(c)
                 select c).ToArray();

            return string.Join("",word);
        }
    }
}
