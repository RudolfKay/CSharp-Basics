using System.Collections.Generic;
using Hierarchy.Animals;
using Hierarchy.Diet;
using System;

namespace Hierarchy
{
    class Program
    {
        private static List<Animal> _animals;

        static void Main()
        {
            _animals = new List<Animal>();

            while (true)
            {
                Console.WriteLine("Enter details of an animal. Type END to quit.\n" +
                                  "Format: Type Name Weight Region (and Breed if cat).\n");
                string animalInput = Console.ReadLine();

                if (animalInput.ToLower().Equals("end"))
                {
                    break;
                }

                string[] animalDetails = animalInput.Split(" ");

                Console.WriteLine("We have meat and vegetables. Which do you want to feed it?\nFormat: Food Amount");
                string foodInput = Console.ReadLine();

                if (foodInput.ToLower().Equals("end"))
                {
                    break;
                }

                string[] foodDetails = foodInput.Split(" ");

                ProcessAnimal(animalDetails, foodDetails);

                Console.ReadKey();
                Console.Clear();
            }

            foreach (Animal animal in _animals)
            {
                Console.WriteLine(animal.ToString());
            }

            Console.ReadKey();
        }

        static void ProcessAnimal(string[] animal, string[] food)
        {
            string animalType = animal[0].ToLower().Trim();
            string animalName = animal[1].ToLower().Trim();
            double animalWeight = double.Parse(animal[2]);
            string animalRegion = animal[3].ToLower().Trim();

            string foodType = food[0];
            int foodCount = int.Parse(food[1]);

            Animal thisAnimal = null;

            if (animalType.Equals("zebra"))
            {
                Animal zebra = new Zebra(animalName,animalType,animalWeight,animalRegion);
                thisAnimal = zebra;

                Console.WriteLine(zebra.MakeSound());
                Feed(zebra, foodType, foodCount);
            }
            else if (animalType.Equals("mouse"))
            {
                Animal mouse = new Mouse(animalName, animalType, animalWeight, animalRegion);
                thisAnimal = mouse;

                Console.WriteLine(mouse.MakeSound());
                Feed(mouse, foodType, foodCount);
            }
            else if (animalType.Equals("lion"))
            {
                Animal lion = new Lion(animalName, animalType, animalWeight, animalRegion);
                thisAnimal = lion;

                Console.WriteLine(lion.MakeSound());
                Feed(lion, foodType, foodCount);
            }
            else if (animalType.Equals("cat"))
            {
                string catBreed = "";

                if (animal.Length < 5)
                {
                    catBreed = "Mixed";
                }
                else
                {
                    catBreed = animal[4].ToLower().Trim();
                }

                Animal cat = new Cat(animalName, animalType, animalWeight, animalRegion, catBreed);
                thisAnimal = cat;

                Console.WriteLine(cat.MakeSound());
                Feed(cat, foodType, foodCount);
            }

            _animals.Add(thisAnimal);
            Console.WriteLine(thisAnimal.ToString()+"\n");
        }

        static void Feed(Animal animal, string food, int quantity)
        {
            if (food.ToLower().Contains("meat"))
            {
                Food meat = new Meat(quantity);
                animal.EatFood(meat);
            }
            else if (food.ToLower().Contains("vegetable"))
            {
                Food veggie = new Vegetable(quantity);
                animal.EatFood(veggie);
            }

            Console.WriteLine();
        }
    }
}