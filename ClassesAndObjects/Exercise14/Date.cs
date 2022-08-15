using System;
using System.Globalization;

namespace Exercise14
{
    public class Date
    {
        private CultureInfo _dutchCi;
        private DateTime _dateTime;
        private int _year;
        private int _month;
        private int _day;

        public Date()
        {
            _dutchCi = new CultureInfo("nl-NL");
        }

        public void WeekdayInDutch(string date)
        {
            _year = int.Parse(date.Split('/')[0]);
            _month = int.Parse(date.Split('/')[1]);
            _day = int.Parse(date.Split('/')[2]);

            _dateTime = new DateTime(_year, _month, _day);

            Console.WriteLine(_dateTime.ToString("dddd", _dutchCi));
        }
    }
}
