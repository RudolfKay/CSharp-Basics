using System;

namespace AdApp
{
    public class Hoarding: Advert
    {
        private int _rate; //per day
        private int _numDays;
        private bool _primeLocation;

        public Hoarding(int fee, int rate, int numDays, bool primeLocation) : base(fee)
        {
            _rate = rate;
            _numDays = numDays;
            _primeLocation = primeLocation;
        }

        public override int Cost()
        {
            var fee = base.Cost();

            return _primeLocation ? fee + (_rate * _numDays) + (int)Math.Round((_rate * _numDays) * 0.5) : fee + (_rate * _numDays);
        }

        public override string ToString()
        {
            var result = base.ToString();
            result += $"\nType: Hoarding\nRate: £{_rate} per Day\nPrime-Location: {_primeLocation}\nTime: {_numDays} days\n";

            return result;
        }
    }
}