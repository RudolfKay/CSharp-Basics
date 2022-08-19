using System;

namespace Exercise6
{
    class DogTest
    {
        static void Main(string[] args)
        {
            Dog dogMax = new Dog("Max", "male");
            Dog dogRocky = new Dog("Rocky", "male");
            Dog dogSparky = new Dog("Sparky", "male");
            Dog dogBuster = new Dog("Buster", "male");
            Dog dogSam = new Dog("Sam", "male");
            Dog dogLady = new Dog("Lady", "female");
            Dog dogMolly = new Dog("Molly", "female");
            Dog dogCoco = new Dog("Coco", "female");
            
            dogMax.AddParents(dogLady,dogRocky);
            dogCoco.AddParents(dogMolly, dogBuster);
            dogRocky.AddParents(dogMolly, dogSam);
            dogBuster.AddParents(dogLady, dogSparky);

            Console.WriteLine(dogCoco.GetFathersName());
            Console.WriteLine(dogSparky.GetFathersName());
            Console.WriteLine(dogCoco.HasSameMotherAs(dogRocky));

            Console.ReadKey();
        }
    }
}
