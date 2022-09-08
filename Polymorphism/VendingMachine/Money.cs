using System.Globalization;

namespace VendingMachine
{
    public struct Money
    {
        public int Euros { get; set; }
        public int Cents { get; set; }
        public CultureInfo FranceCultureInfo;

        public Money(int euros, int cents)
        {
            FranceCultureInfo = CultureInfo.GetCultureInfo("fr-FR");
            Euros = euros;
            Cents = cents;
        }

        public Money(int cents)
        {
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
