namespace Hierarchy
{
    public abstract class Animal
    {
        private string _animalName;
        private string _animalType;
        private double _animalWeight;
        private int _foodEaten;

        protected Animal()
        {
            AnimalName = "Unknown";
            AnimalType = "Unknown";
            AnimalWeight = 0.0;
            FoodEaten = 0;
        }

        protected Animal(string name, string type, double weight)
        {
            AnimalName = name;
            AnimalType = type;
            AnimalWeight = weight;
            FoodEaten = 0;
        }

        protected string AnimalName
        {
            get => _animalName;
            set => _animalName = value;
        }

        protected string AnimalType
        {
            get => _animalType;
            set => _animalType = value;
        }

        protected double AnimalWeight
        {
            get => _animalWeight;
            set => _animalWeight = value;
        }

        protected int FoodEaten
        {
            get => _foodEaten;
            set => _foodEaten = value;
        }

        public override string ToString()
        {
            return $"{AnimalType} ";
        }

        public abstract void MakeSound();

        public abstract void EatFood(Food food);
    }
}
