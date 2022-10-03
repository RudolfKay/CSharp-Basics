using System.Drawing;
using VendingMachine.Exceptions;

namespace VendingMachine
{
    public struct Product
    {
        public int Available { get; set; }
        public Money Price { get; set; }
        public string Name { get; set; }

        public Product(string name, Money price, int numAvailable)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new InvalidNameException();
            }

            if (price.GetTotalCents() <= 0)
            {
                throw new InvalidMoneyException();
            }

            if (numAvailable < 0)
            {
                throw new InvalidProductCountException();
            }

            Name = name;
            Price = price;
            Available = numAvailable;
        }

        public override string ToString()
        {
            return $"{Name}: {Price.ToString()}, Amount: {Available}";
        }
    }
}
