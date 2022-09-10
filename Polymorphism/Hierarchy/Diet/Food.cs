namespace Hierarchy.Diet
{
    public abstract class Food
    {
        private int _quantity;

        protected Food()
        {
            Quantity = 0;
        }

        protected Food(int quantity)
        {
            Quantity = quantity;
        }

        protected int Quantity
        {
            get => _quantity;
            set => _quantity = value;
        }

        public abstract void SetQuantity(int quantity);

        public abstract int GetQuantity();
    }
}
