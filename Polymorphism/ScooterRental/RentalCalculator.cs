using System;

namespace ScooterRental
{
    public class RentalCalculator
    {
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
    }
}
