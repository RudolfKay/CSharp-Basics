using System;
using System.Collections.Generic;
using System.Linq;

namespace DragRace
{
    class Program
    {
        /**
        * Take a look at the cars in this solution.
        * 1. Extract common behaviour to an interface called Car, and use it in the all classes.
        * Which methods will be extracted with an empty body, and which can be default?
        * 2. Create two more cars of your own choice.
        * 3. As you see there is a possibility to use some kind of boost in Lexus, extract it to a new interface
          and add that behaviour in one more car.
        * 4. Create one instance of an each car and add them to list.
        * 5. Iterate over the list 10 times, in the 3rd iteration use speed boost on the car if they have one.
        * 6. Print out the car name and speed of the fastest car
        */

        private static void Main(string[] args)
        {
            ICar audi = new Audi();
            ICar bmw = new Bmw();
            ICar buick = new Buick();
            ICar lexus = new Lexus();
            ICar mcLaren = new McLaren();
            ICar tesla = new Tesla();

            List<ICar> cars = new List<ICar>() { audi, bmw, buick, lexus, mcLaren, tesla };

            for (int i = 0; i <= 10; i++)
            {
                foreach (ICar car in cars)
                {
                    if (i == 0)
                    {
                        car.StartEngine();
                    }
                    else if (i > 0 && i != 3)
                    {
                        car.SpeedUp();
                    }
                    else if (i == 3 && car is INitrous nitrousCar)
                    {
                        nitrousCar.UseNitrousOxideEngine();
                    }
                }
            }

            Console.WriteLine($"Fastest car is: {GetWinner(cars)}");
            Console.ReadKey();
        }

        public static string GetWinner(List<ICar> cars)
        {
            int fastestSpeed = 0;
            string carName = "";

            foreach (ICar car in cars)
            {
                if (car.ShowCurrentSpeed() > fastestSpeed)
                {
                    fastestSpeed = car.ShowCurrentSpeed();
                    carName = car.ToString().Substring(9).Trim();
                }
            }

            return $"{carName}, Final speed: {fastestSpeed}";
        }
    }
}