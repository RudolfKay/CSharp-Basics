using Hierarchy.Exceptions;

namespace Hierarchy.Diet
{
    public class Meat : Food
    {
        public Meat(int quantity) : base(quantity)
        {
        }

        public override void SetQuantity(int quantity)
        {
            if (quantity < 0)
            {
                throw new InvalidFoodQuantityException();
            }

            Quantity = quantity;
        }

        public override int GetQuantity()
        {
            return Quantity;
        }
    }
}
