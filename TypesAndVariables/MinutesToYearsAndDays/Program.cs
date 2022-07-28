using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinutesToYearsAndDays
{
    class Program
    {
        static void Main(string[] args)
        {
            int minutesInDay = 1440;
            int daysInYear = 365;

            Console.WriteLine("Hi! Please enter minutes to convert: ");
            int minutes = Convert.ToInt32(Console.ReadLine());
            
            decimal days = Math.Round((decimal)minutes / minutesInDay);
            int years = (int)days / daysInYear;
            int remainingDays = (int)days - (daysInYear*years);

            Console.WriteLine(days+" "+years+" "+remainingDays);

            Console.WriteLine($"{minutes}min converts to {years} years and {remainingDays} full days");
            Console.ReadKey();
        }
    }
}
