using System;

namespace Exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input base number : ");
            int i = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input number of terms : ");
            int n = Convert.ToInt32(Console.ReadLine());

            int result = i;

            for (int j = 1; j < n; j++)
            {
                result *= i;
            }

            Console.WriteLine($"{i} to the power of {n} is {result}");
            Console.ReadKey();
        }
    }
}
