using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firm
{
    public class Commission : Hourly
    {
        private double _totalSales;
        private double _commissionRate;

        public Commission(string eName, string eAddress, string ePhone, string socSecNumber, double rate, double commissionRate) : base(eName,
            eAddress, ePhone, socSecNumber, rate)
        {
            _commissionRate = commissionRate;
            _totalSales = 0.0;
        }

        public void AddSales(double totalSales)
        {
            _totalSales += totalSales;
        }

        public override double Pay()
        {
            var payment = base.Pay() + (_totalSales * _commissionRate);
            _totalSales = 0;

            return payment;
        }

        public override string ToString()
        {
            var result = base.ToString();
            result += "\nTotal Sales: " + _totalSales;

            return result;
        }
    }
}
