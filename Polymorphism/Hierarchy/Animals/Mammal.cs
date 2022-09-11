using Hierarchy.Exceptions;

namespace Hierarchy.Animals
{
    public abstract class Mammal : Animal
    {
        private string _livingRegion;

        protected Mammal(string name, string type, double weight, string region) : base(name, type, weight)
        {
            if (string.IsNullOrEmpty(region))
            {
                throw new InvalidRegionException();
            }

            LivingRegion = region;
        }

        public string LivingRegion
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
