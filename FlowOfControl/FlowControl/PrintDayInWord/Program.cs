using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintDayInWord
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please select day (0-6): ");
            var input = Console.ReadLine();

            int intCheck = 0;

            while (!int.TryParse(input, out intCheck))
            {
                Console.WriteLine("ERROR: Input is not a number...\nEnter number of day (0-6):");
                input = Console.ReadLine();
            }

            int dayNumber = int.Parse(input);
            Dictionary<int,string> numToDay = new Dictionary<int,string>();

            for (int day = 0; day < 7; day++)
            {
                if (day == 0)
                {
                    numToDay[day] = "Monday";
                }
                else if (day == 1)
                {
                    numToDay[day] = "Tuesday";
                }
                else if (day == 2)
                {
                    numToDay[day] = "Wednesday";
                }
                else if (day == 3)
                {
                    numToDay[day] = "Thursday";
                }
                else if (day == 4)
                {
                    numToDay[day] = "Friday";
                }
                else if (day == 5)
                {
                    numToDay[day] = "Saturday";
                }
                else if (day == 6)
                {
                    numToDay[day] = "Sunday";
                }
            }

            switch (dayNumber)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                    Console.WriteLine(numToDay[dayNumber]);
                    break;
                default:
                    Console.WriteLine("Not a valid day!");
                    break;
            }

            Console.ReadKey();
        }
    }
}
