using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CozaLozaWoza
{
    class Program
    {
        static void Main(string[] args)
        {
            int lowerNum = 1;
            int upperNum = 110;
            int numPerLine = 11;
            string result = "";

            for (int i = lowerNum; i <= upperNum; ++i)
            {
                if (i % 7 == 0 && i % 5 == 0 && i % 3 == 0)
                {
                    result += "CozaLozaWoza ";
                }
                else if (i % 7 == 0)
                {
                    result += "Woza ";
                }
                else if (i % 5 == 0)
                {
                    result += "Loza ";
                }
                else if (i % 3 == 0)
                {
                    result += "Coza ";
                }
                else
                {
                    result += i+" ";
                }

                if (i % numPerLine == 0)
                {
                    result += "\n";
                }
            }

            Console.WriteLine(result.Trim());
            Console.ReadKey();
        }
    }
}
