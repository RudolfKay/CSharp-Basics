namespace Hierarchy.Animals
{
    public abstract class Feline : Mammal
    {
        protected Feline() : base()
        {
        }

        protected Feline(string name, string type, double weight, string region) : base(name, type, weight, region)
        {
        }

        public override string ToString()
        {
            return $"{base.ToString()}";
        }
    }
}
