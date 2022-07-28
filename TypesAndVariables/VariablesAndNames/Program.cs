using System;

namespace VariablesAndNames
{
    class Program
    {
        private static void Main(string[] args)
        {
            int cars = 100;
            double seatsInACar = 4.0;
            int drivers = 28;
            int passengers = 90;
            int carsDriven = drivers;
            int carsNotDriven = cars - carsDriven;
            int carpoolCapacity = ((int)seatsInACar * carsDriven) - drivers;
            double averagePassengersPerCar = Math.Round((double)passengers / carsDriven, 2);

            Console.WriteLine("There are " + cars + " cars available.");
            Console.WriteLine("There are only " + drivers + " drivers available.");
            Console.WriteLine("There will be " + carsNotDriven + " empty cars today.");
            Console.WriteLine("We can transport " + carpoolCapacity + " people today.");
            Console.WriteLine("We have " + passengers + " to carpool today.");
            Console.WriteLine("We need to put about " + averagePassengersPerCar + " in each car.");
            Console.ReadKey();
        }
    }
}