namespace ScooterRental.Interfaces
{
    public interface IRentalCompany
    {
        string Name { get; }
        
        void StartRent(string id);
        
        decimal EndRent(string id);
        /*The total price of rental. It has to calculated taking into account for how long time scooter was rented.
        If total amount per day reaches 20 EUR than timer must be stopped and restarted at beginning of next day at 0:00 am.*/
        
        decimal CalculateIncome(int? year, bool includeNotCompletedRentals);
         /*year = Year of the report. Sum all years if value is not set.
         includeNotCompletedRentals = Include income from the scooters that are rented out (rental has not ended yet),
         and calculate rental price as if the rental would end at the time when this report was requested.
         The total price of all rentals filtered by year if given.*/
    }
}