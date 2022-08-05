using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FirstLetterToUpper
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = { "samuel", "MABELLE", "letitiA", "meridith", "mavis", "SEnAida", "lETTy" };

            Console.WriteLine(string.Join(", ",CapMe(names)));
            Console.ReadKey();
        }

        static string[] CapMe(string[] names)
        {
            string[] answer = new string[names.Length];

            for (int i = 0; i < names.Length; i++)
            {
                string thisName = "";

                for (int x = 0; x < names[i].Length; x++)
                {
                    if (x == 0)
                    {
                        thisName += char.ToUpper(names[i][x]);
                    }
                    else
                    {
                        thisName += char.ToLower(names[i][x]);
                    }
                }

                answer[i] += thisName;
            }

            return answer;
        }
    }
}
