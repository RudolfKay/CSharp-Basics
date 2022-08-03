using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise6
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] myArray1 = new int[10];
            int[] myArray2 = new int[10];
            Random random = new Random();

            for (int i=0; i < myArray1.Length; i++)
            {
                myArray1[i] = random.Next(1,100);
            }

            myArray1.CopyTo(myArray2, 0);

            for (int i = myArray1.Length - 1; i == myArray1.Length - 1; i--)
            {
                myArray1[i] = -7;
            }

            Console.WriteLine($"Array 1: {string.Join(" ", myArray1)}");
            Console.WriteLine($"Array 2: {string.Join(" ", myArray2)}");
            Console.ReadKey();
        }
    }
}
