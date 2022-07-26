﻿using System;
using Hierarchy.Diet;

namespace Hierarchy.Animals
{
    public class Zebra : Mammal
    {
        public Zebra(string name, string type, double weight, string region) : base(name, type, weight, region)
        {
        }

        public override string MakeSound()
        {
            return "...NEEiiigh! Clop, clop, clop...";
        }

        public override void EatFood(Food food)
        {
            var foodType = new Vegetable(1).GetType();

            if (food.GetType() == foodType)
            {
                FoodEaten += food.GetQuantity();
                Console.WriteLine("Calmly picks the food from your hand with lips and chews!");
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
