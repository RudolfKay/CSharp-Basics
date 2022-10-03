using System.Globalization;
using VendingMachine.Exceptions;

namespace VendingMachine
{
    public struct Money
    {
        public int Euros { get; set; }
        public int Cents { get; set; }
        public CultureInfo FranceCultureInfo;

        public Money(int euros, int cents)
        {
            if (euros < 0 || cents < 0)
            {
                throw new InvalidAmountException();
            }

            FranceCultureInfo = CultureInfo.GetCultureInfo("fr-FR");
            Euros = euros;
            Cents = cents;
        }

        public Money(int cents)
        {
            if (cents < 0)
            {
                throw new InvalidAmountException();
            }

            FranceCultureInfo = CultureInfo.GetCultureInfo("fr-FR");
            Euros = (int)cents / 100;
            Cents = cents % 100;
        }

        public int GetTotalCents()
        {
            return (Euros * 100) + Cents;
        }

        public override string ToString()
        {
            return $"{Euros},{Cents:00}Eur";
        }
    }
}
