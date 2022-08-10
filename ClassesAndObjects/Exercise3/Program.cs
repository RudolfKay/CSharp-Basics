using System;

namespace Exercise3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("How much fuel is in your car? ");
            double liters = Convert.ToDouble(Console.ReadLine());
            double fuelMax = 70; // in liters
            int fuelConsumption = 10; // km/l

            FuelGauge testFuel = new FuelGauge(liters, fuelMax);
            
            Console.Write("What's the mileage? ");
            int mileage = Convert.ToInt32(Console.ReadLine());

            Odometer testOdo = new Odometer(mileage, testFuel, fuelConsumption);

            testFuel.FillUp();
            testOdo.Increment();

            Console.ReadKey();
        }
    }
}
