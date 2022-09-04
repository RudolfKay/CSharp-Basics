using System;
using System.Collections.Generic;
using ScooterRental.Exceptions;
using ScooterRental.Interfaces;

namespace ScooterRental
{
    public class RentalHistory
    {
        private Dictionary<Scooter, Dictionary<int, decimal>> _history { get; }
                    //<Key: Scooter, Value: <Key: year, Value: profits.>>
        private IScooterService _scooterService;
        private IList<Scooter> _scooters;

        public RentalHistory(IScooterService scooterService)
        {
            _scooterService = scooterService;
            _scooters = scooterService.GetScooters();
            _history = new Dictionary<Scooter, Dictionary<int, decimal>>();

            foreach (Scooter s in _scooters)
            {
                _history.Add(s, new Dictionary<int,decimal>());
            }
        }

        public void AddIncome(Scooter scooter, int year, decimal income)
        {
            if (scooter == null)
            {
                throw new NullScooterException();
            }

            if (!_history.ContainsKey(scooter))
            {
                throw new ScooterDoesNotExistException(scooter.Id);
            }

            if (year < 2010 || year > 2022)
            {
                throw new YearNotValidException();
            }

            if (income <= 0.00m)
            {
                throw new InvalidIncomeException();
            }

            if (!_history[scooter].ContainsKey(year))
            {
                _history[scooter].Add(year, income);
            }
            else
            {
                Dictionary<int, decimal> info = _history[scooter];

                info[year] += income;
            }
        }

        public Dictionary<Scooter, Dictionary<int, decimal>> GetHistory(int? year)
        {
            if (year == null)
            {
                return _history;
            }
            else
            {
                var historyByYear = new Dictionary<Scooter, Dictionary<int, decimal>>();

                foreach (Scooter s in _history.Keys)
                {
                    Dictionary<int, decimal> info = _history[s];

                    if (info.ContainsKey((int)year))
                    {
                        historyByYear.Add(s, info);
                    }
                }

                return historyByYear;
            }
        }

        public decimal GetIncome(int? year)
        {
            decimal profit = 0.0m;

            if (year == null)
            {
                foreach (Scooter s in _history.Keys)
                {
                    Dictionary<int, decimal> info = _history[s];

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
    }
}
