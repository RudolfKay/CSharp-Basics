using System;

namespace Exercise5
{
    class HappyNum
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a number to check: ");
            var input = Console.ReadLine();

            Console.WriteLine(IsHappyNumber(input));
            Console.ReadKey();
        }

        public static bool IsHappyNumber(string input)
        {
            int n = int.Parse(input);
            int sum = n;
            int x = n;

            if (n == 1 || n == 7)
            {
                return true;
            }

            while (sum > 9)
            {
                sum = 0;

                while (x > 0)
                {
                    int digit = x % 10;
                    sum += digit * digit;
                    x /= 10;
                }

                if (sum == 1)
                {
                    return true;
                }

                x = sum;
            }

            return sum == 7;
        }
    }
}
