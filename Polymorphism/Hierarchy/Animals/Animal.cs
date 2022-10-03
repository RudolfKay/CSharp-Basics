using Hierarchy.Exceptions;
using Hierarchy.Diet;

namespace Hierarchy.Animals
{
    public abstract class Animal
    {
        private string _animalName;
        private string _animalType;
        private double _animalWeight;
        private int _foodEaten;

        protected Animal(string name, string type, double weight)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new InvalidNameException();
            }

            if (string.IsNullOrEmpty(type))
            {
                throw new InvalidTypeException();
            }

            if (weight <= 0)
            {
                throw new InvalidWeightException();
            }

            AnimalName = name;
            AnimalType = type;
            AnimalWeight = weight;
            FoodEaten = 0;
        }

        public string AnimalName
        {
            get => _animalName;
            set => _animalName = value;
        }

        public string AnimalType
        {
            get => _animalType;
            set => _animalType = value;
        }

        public double AnimalWeight
        {
            get => _animalWeight;
            set => _animalWeight = value;
        }

        public int FoodEaten
        {
            get => _foodEaten;
            set => _foodEaten = value;
        }

        public override string ToString()
        {
            return $"{AnimalType}";
        }

        public abstract string MakeSound();

        public abstract void EatFood(Food food);
    }
}
