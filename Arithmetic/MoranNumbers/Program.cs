using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoranNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Moran("132");
            Moran("133");
            Moran("134");
        }

        static void Moran(string number)
        {
            string result;
            int digitSum = 0;

            foreach (char c in number)
            {
                digitSum += int.Parse(c.ToString());
            }

            if (int.Parse(number) % digitSum == 0)
            {
                if (IsPrime(int.Parse(number) / digitSum))
                {
                    result = "M";
                }
                else
                {
                    result = "H";
                }
            }
            else
            {
                result = "Number is neither a Harshad, or Moran number.";
            }

            Console.WriteLine(result);
            Console.ReadKey();
        }

        static bool IsPrime(int n)
        {
            int primeCheck = 0;

            for (int i = 1; i <= n; i++)
            {
                if (n % i == 0)
                {
                    primeCheck++;
                }
            }

            if (primeCheck == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
