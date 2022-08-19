using System;

namespace Exercise14
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();

            Date date = new Date();

            date.WeekdayInDutch("1970/9/21"); // ➞ "maandag"
            date.WeekdayInDutch("1945/9/2"); // ➞ "zondag"
            date.WeekdayInDutch("2001/9/11"); // ➞ "dinsdag"

            Console.ReadKey();
        }
    }
}
