using System;

namespace Exercise11
{
    class ReverseTheCase
    {
        static void Main(string[] args)
        {
            ReverseCase("Happy Birthday");
            ReverseCase("MANY THANKS");
            ReverseCase("sPoNtAnEoUs");
        }

        static void ReverseCase(string input)
        {
            string result = "";

            foreach (char c in input)
            {
                if (c.ToString().Equals(c.ToString().ToUpper()))
                {
                    result += c.ToString().ToLower();
                }
                else
                {
                    result += c.ToString().ToUpper();
                }
            }

            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
