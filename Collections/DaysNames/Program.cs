using System;
using System.Linq;

namespace DaysNames
{
    class Program
    {
        public static void Main(string[] args)
        {
            foreach (var day in Enum.GetNames(typeof(DayOfWeek)))
            {
                Console.WriteLine(day);
            }

            Console.ReadKey();
        }
    }
}
