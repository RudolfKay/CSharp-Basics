using System;

namespace Exercise10
{
    class NumberSquare
    {
        static void Main(string[] args)
        {
            Console.Write($"Min? ");
            int min = Convert.ToInt32(Console.ReadLine());
            Console.Write($"Max? ");
            int max = Convert.ToInt32(Console.ReadLine());

            RotateSquare(min, max);
        }

        static void RotateSquare(int min, int max)
        {
            string startString = "";
            string output = "";
            char currChar = ' ';

            for (int i = 0; i < max; i++)
            {
                if (i == 0)
                {
                    for (int j = min; j <= max; j++)
                    {
                        startString += j;
                    }

                    output = startString;
                    currChar = startString[i];

                    Console.WriteLine(startString);
                }
                else
                {
                    output = output.Substring(1, output.Length-1) + currChar.ToString();
                    currChar = startString[i];

                    Console.WriteLine(output);
                }
            }

            Console.ReadKey();
        }
    }
}
