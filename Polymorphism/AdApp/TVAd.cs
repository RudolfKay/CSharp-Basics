using System.Data.Common;

namespace AdApp
{
    public class TVAd: Advert
    {
        private int _rate;
        private int _time;
        private bool _primeTime;

        public TVAd(int fee, int rate, int seconds, bool primeTime) : base(fee)
        {
            _rate = rate;
            _time = seconds;
            _primeTime = primeTime;
        }
        
        public override int Cost() 
        {
            return _primeTime ? base.Cost() + ((_rate * 2) * _time) : base.Cost() + (_rate * _time);
        }

        public override string ToString()
        {
            var result = base.ToString();
            result += $"\nType: TV Ad\nRate: £{_rate} per sec.\nPrime-Time: {_primeTime}.\nTime: {_time}sec\n";

            return result;
        }
    }
}