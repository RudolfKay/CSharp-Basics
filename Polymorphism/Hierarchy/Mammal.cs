namespace Hierarchy
{
    public abstract class Mammal : Animal
    {
        private string _livingRegion;

        protected Mammal() : base()
        {
        }

        protected Mammal(string name, string type, double weight, string region) : base(name, type, weight)
        {
            LivingRegion = region;
        }

        protected string LivingRegion
        {
            get => _livingRegion;
            set => _livingRegion = value;
        }

        public override string ToString()
        {
            return $"{base.ToString()} [{AnimalName}, {LivingRegion}, {AnimalWeight}, {FoodEaten}]";
        }
    }
}
