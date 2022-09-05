using System;
using ScooterRental.Exceptions;
using ScooterRental.Interfaces;
using System.Collections.Generic;

namespace ScooterRental
{
    public class RentalHistory
    {
        private readonly IList<Scooter> _scooters;
        private Dictionary<Scooter, Dictionary<int, decimal>> History { get; }
                    //<Key: Scooter, Value: <Key: year, Value: profit>>

        public RentalHistory(IScooterService scooterService)
        {
            _scooters = scooterService.GetScooters();
            History = new Dictionary<Scooter, Dictionary<int, decimal>>();

            foreach (Scooter s in _scooters)
            {
                History.Add(s, new Dictionary<int, decimal>());
            }
        }

        public void UpdateRental(Scooter s, int? year, decimal profit)
        {
            var yearAndProfit = new Dictionary<int, decimal>();

            if (year == null)
            {
                int thisYear = DateTime.UtcNow.Year;
                yearAndProfit.Add(thisYear, profit);
            }
            else
            {
                yearAndProfit.Add((int)year, profit);
            }

            History[s] = yearAndProfit;
        }

        public void AddIncome(Scooter scooter, int year, decimal income)
        {
            if (scooter == null)
            {
                throw new NullScooterException();
            }

            if (!History.ContainsKey(scooter))
            {
                throw new ScooterDoesNotExistException(scooter.Id);
            }

            if (year < 2010 || year > 2022)
            {
                throw new YearNotValidException();
            }

            if (income < 0.00m)
            {
                throw new InvalidIncomeException();
            }

            if (!History[scooter].ContainsKey(year))
            {
                History[scooter].Add(year, income);
            }
            else
            {
                Dictionary<int, decimal> info = History[scooter];

                info[year] += income;
                History[scooter] = info;
            }
        }

        public decimal GetIncome(int? year)
        {
            decimal profit = 0.0m;

            if (year == null)
            {
                foreach (Scooter s in History.Keys)
                {
                    Dictionary<int, decimal> info = History[s];

                    foreach (int key in info.Keys)
                    {
                        profit += info[key];
                    }
                }
            }
            else
            {
                Dictionary<Scooter, Dictionary<int, decimal>> historyByYear = GetHistory(year);

                foreach (Scooter s in historyByYear.Keys)
                {
                    Dictionary<int, decimal> info = historyByYear[s];

                    profit += info[(int)year];
                }
            }

            return profit;
        }

        public Dictionary<Scooter, Dictionary<int, decimal>> GetHistory(int? year)
        {
            if (year == null)
            {
                return History;
            }

            var historyByYear = new Dictionary<Scooter, Dictionary<int, decimal>>();

            foreach (Scooter s in History.Keys)
            {
                Dictionary<int, decimal> info = History[s];

                if (info.ContainsKey((int)year))
                {
                    historyByYear.Add(s, info);
                }
            }

            return historyByYear;
        }
    }
}
