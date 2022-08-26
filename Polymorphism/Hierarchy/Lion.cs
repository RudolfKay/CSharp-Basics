using System;

namespace Hierarchy
{
    public class Lion : Feline
    {
        public Lion() : base()
        {
        }

        public Lion(string name, string type, double weight, string region) : base(name, type, weight, region)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("..rrROAAARrr...");
        }

        public override void EatFood(Food food)
        {
            var foodType = new Meat().GetType();

            if (food.GetType() == foodType)
            {
                FoodEaten += food.GetQuantity();
                Console.WriteLine("Roars and eats the meat chunk by chunk!");
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
