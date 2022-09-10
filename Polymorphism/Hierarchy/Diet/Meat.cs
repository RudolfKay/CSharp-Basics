namespace Hierarchy.Diet
{
    public class Meat : Food
    {
        public Meat()
        {
        }

        public Meat(int quantity) : base(quantity)
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
