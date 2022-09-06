﻿using ScooterRental.Exceptions;
using ScooterRental.Interfaces;
using System;
using System.Linq;

namespace ScooterRental
{
    public class RentalCompany : IRentalCompany
    {
        public string Name { get; }
        private readonly IScooterService _scooterService;
        private readonly RentalHistory _rentalHistory;
        private readonly RentalCalculator _rentalCalculator;

        public RentalCompany(string companyName, RentalHistory rentalHistory, IScooterService scooterService, RentalCalculator rentalCalculator)
        {
            Name = companyName;
            _scooterService = scooterService;
            _rentalHistory = rentalHistory;
            _rentalCalculator = rentalCalculator;
        }

        public void StartRent(string id)
        {
            var scooter = _scooterService.GetScooterById(id);

            if (string.IsNullOrEmpty(id))
            {
                throw new InvalidIdException();
            }

            if (scooter == null)
            {
                throw new ScooterDoesNotExistException(id);
            }

            scooter.IsRented = true;
            _rentalHistory.AddRent(scooter, DateTime.UtcNow);
        }

        public decimal EndRent(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new InvalidIdException();
            }

            var scoot = _scooterService.GetScooterById(id);

            if (scoot == null)
            {
                throw new ScooterDoesNotExistException(id);
            }

            var rental = _rentalHistory.UpdateRental(scoot, DateTime.Now);

            scoot.IsRented = false;
            decimal fee = _rentalCalculator.GetFee(rental);

            _rentalHistory.AddIncome(scoot, rental.EndTime.Value.Year, fee);

            return fee;
        }

        public decimal CalculateIncome(int? year, bool includeNotCompletedRentals)
        {
            if (year.HasValue)
            {
                if (includeNotCompletedRentals && year.Value != DateTime.Today.Year)
                {
                    throw new InvalidOperationException();
                }

                var items = _rentalHistory.GetHistory(year);
                var profit = items.Select(i => i.Value[year.Value]).Sum();

                if (includeNotCompletedRentals)
                {
                    var incompleteRentals = _rentalHistory.GetIncompleteRentals(year);

                    foreach (var rentedScooter in incompleteRentals)
                    {
                        rentedScooter.EndTime = DateTime.UtcNow;
                        profit += _rentalCalculator.GetFee(rentedScooter);
                    }
                }

                return profit;
            }

            if (!includeNotCompletedRentals)
            {
                var items = _rentalHistory.GetHistory(null);
                var profit = items.Select(i => i.Value.Values.Sum()).Sum();

                return profit;
            }
            else
            {
                var items = _rentalHistory.GetHistory(null);
                var profit = items.Select(i => i.Value.Values.Sum()).Sum();
                var incompleteRentals = _rentalHistory.GetIncompleteRentals(null);

                foreach (var rentedScooter in incompleteRentals)
                {
                    rentedScooter.EndTime = DateTime.UtcNow;
                    profit += _rentalCalculator.GetFee(rentedScooter);
                }

                return profit;
            }
        }

        /*public decimal CalculateIncome(int? year, bool includeNotCompletedRentals)
        {
            RentalHistory tempHistory = new(_scooterService);
            List<RentedScooter> tempRentedScooters = new(_rentedScooters);
            Dictionary<Scooter, Dictionary<int, decimal>> scooterHistory = tempHistory.GetHistory(year ?? null);

            if (tempRentedScooters.Count < 1)
            {
                throw new NoScootersFoundException();
            }

            if (includeNotCompletedRentals)
            {
                foreach (RentedScooter rentedScooter in tempRentedScooters.Where(x => !x.EndTime.HasValue))
                {
                    rentedScooter.EndTime = DateTime.UtcNow;
                    DateTime endTime = (DateTime)rentedScooter.EndTime;
                    int tempYear = endTime.Year;

                    string rentedId = rentedScooter.Id;
                    decimal currentFee = GetFee(rentedScooter);

                    foreach (Scooter s in scooterHistory.Keys)
                    {
                        string thisId = s.Id;

                        if (thisId.Equals(rentedId))
                        {
                            tempHistory.AddIncome(s, tempYear, currentFee);
                        }
                    }
                }
            }
            else
            {
                foreach (RentedScooter rentedScooter in tempRentedScooters.Where(x => x.EndTime.HasValue))
                {
                    DateTime endTime = (DateTime)rentedScooter.EndTime;
                    int tempYear = endTime.Year;

                    string rentedId = rentedScooter.Id;
                    decimal currentFee = GetFee(rentedScooter);


                    foreach (Scooter s in scooterHistory.Keys)
                    {
                        string thisId = s.Id;

                        if (thisId.Equals(rentedId))
                        {
                            tempHistory.AddIncome(s, tempYear, currentFee);
                        }
                    }
                }
            }

            if (year == null)
            {
                return tempHistory.GetIncome(null);
            }

            return tempHistory.GetIncome(year);
        }*/
    }
}
