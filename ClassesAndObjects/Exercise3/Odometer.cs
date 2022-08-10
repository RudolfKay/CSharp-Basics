using System;

namespace Exercise3
{
    class Odometer
    {
        private int _mileage;
        private int _fuelBurnRate;
        private FuelGauge _fuel;

        public Odometer(int startingMileage, FuelGauge fuel, int fuelBurnRate)
        {
            _mileage = startingMileage;
            _fuel = fuel;
            _fuelBurnRate = fuelBurnRate;
        }

        public int GetMileage()
        {
            return _mileage;
        }

        public void Increment()
        {
            int kmCount = 0;

            while (_fuel.GetFuel() > 0)
            {
                if (kmCount % _fuelBurnRate == 0)
                {
                    Console.WriteLine($"Driving... {_fuel.GetFuel()}l remaining.");
                    _fuel.Burn();
                    Console.WriteLine($"You've driven {kmCount}km. Total mileage is {_mileage}km");
                }

                _mileage = _mileage < 999999 ? _mileage += 1 : _mileage = 0;
                kmCount++;
            }

            if (_fuel.GetFuel() == 0)
            {
                Console.WriteLine("\nThe car ran out of fuel.");
                Console.WriteLine($"You drove {kmCount}km. Your total mileage is now {_mileage}km");
            }
        }
    }
}
