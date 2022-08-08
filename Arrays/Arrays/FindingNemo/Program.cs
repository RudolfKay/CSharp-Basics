using System;

namespace FindingNemo
{
    class Program
    {
        static void Main(string[] args)
        {
            FindNemo("I am finding Nemo !");
            FindNemo("Nemo is me");
            FindNemo("I Nemo am");
        }

        static void FindNemo(string s)
        {
            string[] input = s.Split(' ');
            bool isNemoFound = new bool();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].Equals("Nemo"))
                {
                    Console.WriteLine($"I found Nemo at {i+1}!");
                    isNemoFound = true;
                    break;
                }
            }

            if (!isNemoFound)
            {
                Console.WriteLine("I can't find Nemo :(");
            }

            Console.ReadKey();
        }
    }
}
