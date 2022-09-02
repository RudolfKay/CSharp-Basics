using ScooterRental.Exceptions;
using ScooterRental.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ScooterRental
{
    public class RentalCompany : IRentalCompany
    {
        public string Name { get; }
        private readonly List<RentedScooter> _rentedScooters;
        private readonly ScooterService _scooterService;
        private readonly RentalHistory _rentalHistory;

        public RentalCompany(string companyName, List<RentedScooter> rentedScooters, ScooterService scooterService)
        {
            Name = companyName;
            _rentedScooters = rentedScooters;
            _scooterService = scooterService;
            _rentalHistory = new RentalHistory(scooterService);
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
            _rentedScooters.Add(new RentedScooter(id, scooter.PricePerMinute, DateTime.UtcNow));
        }

        public decimal EndRent(string id)
        {
            var scoot = _scooterService.GetScooterById(id);
            var rentedScoot = _rentedScooters.FirstOrDefault(scooter => scooter.Id == id && !scooter.EndTime.HasValue);
            rentedScoot.EndTime = DateTime.UtcNow;
            scoot.IsRented = false;

            if (string.IsNullOrEmpty(id))
            {
                throw new InvalidIdException();
            }

            if (scoot == null)
            {
                throw new ScooterDoesNotExistException(id);
            }

            TimeSpan rentTimeSpan = (DateTime)rentedScoot.EndTime - rentedScoot.StarTime;

            return scoot.PricePerMinute * (decimal)rentTimeSpan.TotalMinutes;
        }

        public decimal CalculateIncome(int? year, bool includeNotCompletedRentals)
        {
            RentalHistory tempHistory = new RentalHistory(_scooterService);
            Dictionary<Scooter, Dictionary<int, decimal>> scooterHistory = tempHistory.GetHistory(year);

            if (includeNotCompletedRentals && year != null)
            {
                foreach (RentedScooter rentedScooter in _rentedScooters)
                {
                    rentedScooter.EndTime = DateTime.UtcNow;
                    TimeSpan rentTimeSpan = (DateTime)rentedScooter.EndTime - rentedScooter.StarTime;
                    string rentedId = rentedScooter.Id;
                    decimal currentFee = rentedScooter.PricePerMinute * (decimal)rentTimeSpan.TotalMinutes;

                    foreach (Scooter s in scooterHistory.Keys)
                    {
                        string thisId = s.Id;

                        if (thisId.Equals(rentedId))
                        {
                            tempHistory.AddIncome(s, (int)year, currentFee);
                        }
                    }
                }

                return tempHistory.GetIncome(year);
            }

            return _rentalHistory.GetIncome(year);
        }
    }
}
