using Hierarchy.Exceptions;

namespace Hierarchy.Diet
{
    public abstract class Food
    {
        protected int Quantity { get; set; }

        protected Food(int quantity)
        {
            if (quantity < 0)
            {
                throw new InvalidFoodQuantityException();
            }

            Quantity = quantity;
        }

        public abstract void SetQuantity(int quantity);

        public abstract int GetQuantity();
    }
}
