using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3
{
    public class FuelGauge
    {
        private double _maxFuelAmount;
        private double _currentFuel;

        public FuelGauge(double liters, double maxFuel)
        {
            _maxFuelAmount = maxFuel;
            _currentFuel = liters;
        }

        public double GetFuel()
        {
            return _currentFuel;
        }

        public void FillUp()
        {
            while( _currentFuel < _maxFuelAmount)
            {
                _currentFuel += 1;
                Console.WriteLine($"Pumping fuel... {_currentFuel} l");
            }

            if (_currentFuel == _maxFuelAmount)
            {
                Console.WriteLine("The car is fully fueled...");
            }
        }

        public void Burn()
        {
            _currentFuel--;
        }
    }
}
