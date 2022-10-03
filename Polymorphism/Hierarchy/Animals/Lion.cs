using System;
using Hierarchy.Diet;

namespace Hierarchy.Animals
{
    public class Lion : Feline
    {
        public Lion(string name, string type, double weight, string region) : base(name, type, weight, region)
        {
        }

        public override String MakeSound()
        {
            return "...rrROAAARrr...";
        }

        public override void EatFood(Food food)
        {
            var foodType = new Meat(1).GetType();

            if (food.GetType() == foodType)
            {
                FoodEaten += food.GetQuantity();
                Console.WriteLine("Eats the meat chunk by chunk!");
            }
            else
            {
                Console.WriteLine($"{AnimalType}s can't eat that...");
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()}";
        }
    }
}
