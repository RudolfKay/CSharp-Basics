namespace Hierarchy.Diet
{
    public class Vegetable : Food
    {
        public Vegetable()
        {
        }

        public Vegetable(int quantity) : base(quantity)
        {
        }

        public override void SetQuantity(int quantity)
        {
            Quantity = quantity;
        }

        public override int GetQuantity()
        {
            return Quantity;
        }
    }
}
