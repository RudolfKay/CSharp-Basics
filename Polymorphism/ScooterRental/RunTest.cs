using ScooterRental.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScooterRental
{
    public class RunTest
    {
        private static List<Scooter> _inventory;
        private static List<RentedScooter> _rentedInventory;
        private static ScooterService _scooterService;
        private static RentalCompany _rentalCompany;
        private static RentalHistory _rentalHistory;

        public static void Main(string[] args)
        {
            _inventory = new List<Scooter>();
            _rentedInventory = new List<RentedScooter>();
            _scooterService = new ScooterService(_inventory);

            for (int i = 1; i <= 5; i++)
            {
                _scooterService.AddScooter($"{i}", 0.2m);
            }

            _rentalCompany = new RentalCompany("Cheeki Breeki", _rentedInventory, _scooterService);
            _rentalHistory = new RentalHistory(_scooterService);

            _rentalCompany.StartRent("1");
            _rentalCompany.StartRent("5");

            foreach (var scooter in _rentedInventory)
            {
                if (scooter.Id.Equals("1"))
                {
                    scooter.StarTime = new DateTime(2022, 09, 03, 0, 0, 0);
                }

                if (scooter.Id.Equals("5"))
                {
                    scooter.StarTime = new DateTime(2022, 09, 01, 20, 0, 0);
                }
            }

            Console.WriteLine($"Fee: {_rentalCompany.EndRent("1")}");
            Console.WriteLine($"Fee: {_rentalCompany.EndRent("5")}");

            Console.ReadLine();
        }
    }
}
