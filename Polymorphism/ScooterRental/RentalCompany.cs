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
        private readonly IScooterService _scooterService;
        private readonly RentalHistory _rentalHistory;

        public RentalCompany(string companyName, List<RentedScooter> rentedInventory, ScooterService scooterService)
        {
            Name = companyName;
            _rentedScooters = rentedInventory;
            _scooterService = scooterService;
            _rentalHistory = new(scooterService);
        }

        public RentalCompany(string companyName, List<RentedScooter> rentedInventory, IScooterService scooterService)
        {
            Name = companyName;
            _rentedScooters = rentedInventory;
            _scooterService = scooterService;
            _rentalHistory = new(scooterService);
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
            _rentedScooters.Add(new(id, scooter.PricePerMinute, DateTime.UtcNow));
            //_rentalHistory.AddRental(scooter);
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
            DateTime endTime = (DateTime)rentedScoot.EndTime;
            scoot.IsRented = false;
            decimal fee = GetFee(rentedScoot);
            //_rentalHistory.AddRental(scoot, endTime.Year, fee);
            _rentalHistory.AddIncome(scoot, endTime.Year, fee);

            return fee;
        }

        public decimal GetFee(RentedScooter rentedScooter)
        {
            //Scooter scooter = _scooterService.GetScooterById(rentedScooter.Id);
            DateTime startRentTime = rentedScooter.StarTime;
            DateTime endRentTime = (DateTime)rentedScooter.EndTime;
            TimeSpan timeSpanRented = endRentTime - startRentTime;

            decimal pricePerMin = rentedScooter.PricePerMinute;
            decimal amount = 0.0m;
            decimal maxDailyCharge = 20.0m;

            //int year = endRentTime.Year;
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

            //_rentalHistory.AddIncome(scooter, year, amount);
            return amount;
        }

        public decimal CalculateIncome(int? year, bool includeNotCompletedRentals)
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
        }
    }
}
