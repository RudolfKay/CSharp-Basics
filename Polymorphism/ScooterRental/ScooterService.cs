using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScooterRental.Exceptions;
using ScooterRental.Interfaces;

namespace ScooterRental
{
    public class ScooterService : IScooterService
    {
        private List<Scooter> _scooters;

        public ScooterService(List<Scooter> inventory)
        {
            _scooters = inventory;
        }
        public void AddScooter(string id, decimal pricePerMinute)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new InvalidIdException();
            }
            //var scooter = _scooters.FirstOrDefault(scooter => scooter.Id == id);
            if (pricePerMinute < 0)
            {
                throw new InvalidPriceException(pricePerMinute);
            }

            if (_scooters.Any(scooter => scooter.Id == id))
            {
                throw new DuplicateScooterException(id);
            }

            _scooters.Add(new Scooter(id, pricePerMinute));
        }

        public void RemoveScooter(string id)
        {
            var scooter = _scooters.FirstOrDefault(scooter => scooter.Id == id);
            throw new NotImplementedException();
        }

        public Scooter GetScooterById(string scooterId)
        {
            throw new NotImplementedException();
        }
    }
}
