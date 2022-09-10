using System;
using Hierarchy.Diet;

namespace Hierarchy.Animals
{
    public class Cat : Feline
    {
        private string _catBreed;

        public Cat() : base()
        {
            CatBreed = "Unknown";
        }

        public Cat(string name, string type, double weight, string region, string catBreed) : base(name, type, weight, region)
        {
            CatBreed = catBreed;
        }

        private string CatBreed
        {
            get => _catBreed;
            set => _catBreed = value;
        }

        public override void MakeSound()
        {
            Console.WriteLine("Meow...Mrr..");
        }

        public override void EatFood(Food food)
        {
            FoodEaten += food.GetQuantity();
            Console.WriteLine($"{AnimalType} eats it with delight and meows for more!");
        }

        public override string ToString()
        {
            return $"{AnimalType} [{AnimalName}, {CatBreed}, {LivingRegion}, {AnimalWeight}, {FoodEaten}]";
        }
    }
}
