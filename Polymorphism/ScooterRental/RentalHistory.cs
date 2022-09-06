using System;
using ScooterRental.Exceptions;
using ScooterRental.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ScooterRental
{
    public class RentalHistory
    {
        private Dictionary<Scooter, Dictionary<int, decimal>> History { get; }
                    //<Key: Scooter, Value: <Key: year, Value: profit>>
        private List<RentedScooter> _history;

        public RentalHistory(List<RentedScooter> history)
        {
            History = new Dictionary<Scooter, Dictionary<int, decimal>>();
            _history = history;
        }

        public void AddRent(Scooter scooter, DateTime starTime)
        {
            _history.Add(new RentedScooter(scooter.Id, scooter.PricePerMinute, starTime));
        }

        public RentedScooter UpdateRental(Scooter scooter, DateTime endTime)
        {
            var rental = _history.FirstOrDefault(s => s.Id == scooter.Id && !s.EndTime.HasValue);

            if (rental == null)
            {
                throw new NullScooterException();

            }

            rental.EndTime = endTime;

            return rental;
        }

        public void AddIncome(Scooter scooter, int year, decimal income)
        {
            if (scooter == null)
            {
                throw new NullScooterException();
            }

            if (!History.ContainsKey(scooter))
            {
                History.Add(scooter, new Dictionary<int, decimal>());
                //throw new ScooterDoesNotExistException(scooter.Id);
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
                History[scooter][year] += income;
            }
        }

        /*public decimal GetIncome(int? year)
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
        }*/

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

                if (info.ContainsKey(year.Value))
                {
                    //var income = info[year.Value];
                    historyByYear.Add(s, info);
                }
            }

            return historyByYear;
        }

        public List<RentedScooter> GetIncompleteRentals(int? year)
        {
            var rentals = _history.Where(r => !r.EndTime.HasValue).ToList();

            if (year.HasValue)
            {
                rentals = rentals.Where(r => r.StarTime.Year == year).ToList();
            }

            return rentals;
        }
    }
}
