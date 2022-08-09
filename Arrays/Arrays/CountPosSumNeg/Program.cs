using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountPosSumNeg
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, -11, -12, -13, -14, -15 };
            
            int posNumCount = 0;
            int negSum = 0;

            foreach (int n in numbers)
            {
                if (n > 0)
                {
                    posNumCount++;
                }
                else
                {
                    negSum += n;
                }
            }

            Console.WriteLine(string.Join(" ",PosNegArray(posNumCount, negSum)));
            Console.ReadKey();
        }

        static int[] PosNegArray(int posCount, int negSum)
        {
            int[] answer = {};

            if (posCount != 0 && negSum != 0)
            {
                answer = new int[2];
                answer[0] = posCount;
                answer[1] = negSum;
            }

            return answer;
        }
    }
}
