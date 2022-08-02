using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Employee 1
            decimal pay1 = (decimal)7.50;
            int hours1 = 35;

            //Employee 2
            decimal pay2 = (decimal)8.20;
            int hours2 = 47;

            //Employee 3
            decimal pay3 = 10;
            int hours3 = 73;

            Calculate(pay1, hours1);
            Calculate(pay2, hours2);
            Calculate(pay3, hours3);
        }

        static void Calculate(decimal basePay, int hoursWorked)
        {
            decimal overTimePay = basePay * (decimal)1.5;
            decimal minWage = (decimal)8.00;
            int standardHours = 40;
            int maxHours = 60;
            decimal paycheck = 0;

            if (basePay < minWage)
            {
                Console.WriteLine("ERROR: Base pay is below minimum wage!");
                Console.ReadKey();
            }
            else if (hoursWorked > maxHours)
            {
                Console.WriteLine("ERROR: Hours worked exceed maximum!");
                Console.ReadKey();
            }
            else
            {
                for (int i=1; i <= hoursWorked; i++)
                {
                    if (i <= standardHours)
                    {
                        paycheck += basePay;
                    }
                    else if (i > standardHours)
                    {
                        paycheck += overTimePay;
                    }
                }

                Console.WriteLine($"Pay for this Employee is {paycheck}$");
                Console.ReadKey();
            }
        }
    }
}
