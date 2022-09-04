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

            if (string.IsNullOrEmpty(id))
            {
                throw new InvalidIdException();
            }

            if (scoot == null)
            {
                throw new ScooterDoesNotExistException(id);
            }

            rentedScoot.EndTime = DateTime.UtcNow;
            TimeSpan rentTimeSpan = (DateTime)rentedScoot.EndTime - rentedScoot.StarTime;
            scoot.IsRented = false;
            //_rentedScooters.Remove(rentedScoot);

            return GetFee(rentTimeSpan, scoot.PricePerMinute);
        }

        public decimal GetFee(TimeSpan timeRented, decimal pricePerMin)
        {
            decimal amount = 0.0m;
            decimal maxDailyCharge = 20.0m;

            int totalMinutesRented = (int)timeRented.TotalMinutes;
            int fullDaysRented = (int)timeRented.TotalDays;
            int minutesInDay = 1440;
            int hours = timeRented.Hours;
            int minutes = timeRented.Minutes;

            if (fullDaysRented > 0)
            {
                amount += (maxDailyCharge * fullDaysRented);
            }

            if ((hours * 60 + minutes) * pricePerMin < maxDailyCharge)
            {
                amount += (minutes + hours * 60) * pricePerMin;
            }

            if ((hours * 60 + minutes) * pricePerMin > maxDailyCharge)
            {
                amount += maxDailyCharge;
            }
            /*else
            {
                amount += totalMinutesRented * pricePerMin;
            }*/

            return amount;
        }

        public decimal CalculateIncome(int? year, bool includeNotCompletedRentals)
        {
            List<RentedScooter> tempRentedScooters = new List<RentedScooter>(_rentedScooters);
            RentalHistory tempHistory = new RentalHistory(_scooterService);
            Dictionary<Scooter, Dictionary<int, decimal>> scooterHistory = tempHistory.GetHistory(year);

            if (includeNotCompletedRentals && year != null)
            {
                foreach (RentedScooter rentedScooter in tempRentedScooters)
                {
                    rentedScooter.EndTime = DateTime.UtcNow;
                    TimeSpan rentTimeSpan = (DateTime)rentedScooter.EndTime - rentedScooter.StarTime;

                    string rentedId = rentedScooter.Id;
                    decimal currentFee = GetFee(rentTimeSpan, rentedScooter.PricePerMinute);

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
