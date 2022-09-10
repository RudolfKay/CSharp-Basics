using System;
using Hierarchy.Diet;

namespace Hierarchy.Animals
{
    public class Mouse : Mammal
    {
        public Mouse() : base()
        {
        }

        public Mouse(string name, string type, double weight, string region) : base(name, type, weight, region)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("..squeek..squeeeeek..."); ;
        }

        public override void EatFood(Food food)
        {
            var foodType = new Vegetable().GetType();

            if (food.GetType() == foodType)
            {
                FoodEaten += food.GetQuantity();
                Console.WriteLine("Happily squeaks and nibbles on food!");
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
