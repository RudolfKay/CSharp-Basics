using System;

namespace Exercise3
{
    class Program
    {
        private static void Main(string[] args)
        {
            int[] numbers = {20, 30, 25, 35, -16, 60, -100};

            int numCount = 0;
            double sum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
                numCount += 1;
            }
            
            double average = Math.Round(sum/numCount, 2);
            
            Console.WriteLine("Average value of the array elements is : " + average);
            Console.ReadKey();
        }
    }
}
