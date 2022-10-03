using Hierarchy.Exceptions;
using Hierarchy.Diet;
using System;

namespace Hierarchy.Animals
{
    public class Cat : Feline
    {
        private string _catBreed;

        public Cat(string name, string type, double weight, string region, string catBreed) : base(name, type, weight, region)
        {
            if (string.IsNullOrEmpty(catBreed))
            {
                throw new InvalidBreedException();
            }

            CatBreed = catBreed;
        }

        public string CatBreed
        {
            get => _catBreed;
            set => _catBreed = value;
        }

        public override string MakeSound()
        {
            return "Meow...Mrr..";
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
