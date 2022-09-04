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
            scoot.IsRented = false;
            //_rentedScooters.Remove(rentedScoot);

            return GetFee(rentedScoot);
        }

        public decimal GetFee(RentedScooter rentedScooter)
        {
            DateTime startRentTime = rentedScooter.StarTime;
            DateTime endRentTime = (DateTime)rentedScooter.EndTime;
            TimeSpan timeSpanRented = endRentTime - startRentTime;

            decimal pricePerMin = rentedScooter.PricePerMinute;
            decimal amount = 0.0m;
            decimal maxDailyCharge = 20.0m;

            int fullDaysRented = (int)timeSpanRented.TotalDays;
            int hourDifference = (int)timeSpanRented.Hours;
            int minuteDifference = (int)timeSpanRented.Minutes;
            int startHours = startRentTime.Hour;
            int endHours = endRentTime.Hour;
            int endMinutes = endRentTime.Minute;

            if (fullDaysRented > 0)
            {
                amount += (maxDailyCharge * fullDaysRented);

                if (startHours > endHours)
                {
                    if ((60 * endHours + endMinutes) * pricePerMin < maxDailyCharge)
                    {
                        amount += (60 * endHours + endMinutes) * pricePerMin;
                    }

                    if ((60 * endHours + endMinutes) * pricePerMin > maxDailyCharge)
                    {
                        amount += maxDailyCharge;
                    }
                }

                else if (startHours < endHours)
                {
                    if ((60 * hourDifference + minuteDifference) * pricePerMin < maxDailyCharge)
                    {
                        amount += (60 * hourDifference + minuteDifference) * pricePerMin;
                    }

                    if ((60 * hourDifference + minuteDifference) * pricePerMin > maxDailyCharge)
                    {
                        amount += maxDailyCharge;
                    }
                }
            }

            if (fullDaysRented == 0)
            {
                if (startHours > endHours)
                {
                    if ((60 * hourDifference + minuteDifference) * pricePerMin < maxDailyCharge)
                    {
                        amount += (60 * hourDifference + minuteDifference) * pricePerMin;
                    }

                    if ((60 * hourDifference + minuteDifference) * pricePerMin > maxDailyCharge)
                    {
                        amount += maxDailyCharge;
                    }
                }

                else if (startHours < endHours)
                {
                    if ((60 * hourDifference + minuteDifference) * pricePerMin < maxDailyCharge)
                    {
                        amount += (60 * hourDifference + minuteDifference) * pricePerMin;
                    }

                    if ((60 * hourDifference + minuteDifference) * pricePerMin > maxDailyCharge)
                    {
                        amount += maxDailyCharge;
                    }
                }
            }

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

                    string rentedId = rentedScooter.Id;
                    decimal currentFee = GetFee(rentedScooter);

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
