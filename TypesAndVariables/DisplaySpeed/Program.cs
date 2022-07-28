using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisplaySpeed
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please input distance and time when prompted to convert.\nWhat is the distance(meters)?");
            decimal userDistance = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Input the hours:");
            decimal userHours = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Input the minutes:");
            decimal userMinutes = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Input the seconds:");
            decimal userSeconds = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Converting......");
            decimal distanceKm = userDistance / 1000;
            decimal distanceMi = userDistance / 1609;
            decimal timeInH = userHours + (userMinutes / 60) + ((userSeconds / 60) / 60);
            decimal timeInSec = userSeconds + (userMinutes * 60) + ((userHours * 60) * 60);

            Console.WriteLine($"Results:\nSpeed in m/s: {decimal.Round(GetSpeed(userDistance, timeInSec), 8, MidpointRounding.ToEven)}\n" +
                              $"Speed in Km/h: {decimal.Round(GetSpeed(distanceKm, timeInH), 8, MidpointRounding.ToEven)}\n" +
                              $"Speed in Mi/h: {decimal.Round(GetSpeed(distanceMi, timeInH), 8, MidpointRounding.ToEven)}");
            Console.ReadKey();
        }
        
        static decimal GetSpeed(decimal distance, decimal time)
        {
            return distance / time;
        }
    }
}
