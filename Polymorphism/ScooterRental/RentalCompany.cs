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

        public RentalCompany(string companyName, List<RentedScooter> rentedScooters, IScooterService scooterService)
        {
            Name = companyName;
            _rentedScooters = rentedScooters;
            _scooterService = scooterService;
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

            return scoot.PricePerMinute;
        }

        public decimal CalculateIncome(int? year, bool includeNotCompletedRentals)
        {
            throw new NotImplementedException();
        }
    }
}
