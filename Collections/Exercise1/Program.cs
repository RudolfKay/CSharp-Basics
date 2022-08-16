using System;
using System.Collections.Generic;

namespace Exercise1
{
    class Program
    {
        /**
           * Origination:
           * Audi -> Germany
           * BMW -> Germany
           * Honda -> Japan
           * Mercedes -> Germany
           * Volkswagen -> Germany
           * Tesla -> USA
           */

        private static void Main(string[] args)
        {
            string[] array = { "Audi", "BMW", "Honda", "Mercedes", "Volkswagen", "Mercedes", "Tesla" };

            List<string> carsList = new List<string>(array);

            foreach (string car in carsList)
            {
                Console.WriteLine(car);
            }

            Console.WriteLine();

            HashSet<string> carsHashSet = new HashSet<string>(array);

            foreach (string car in carsHashSet)
            {
                Console.WriteLine(car);
            }

            Console.WriteLine();

            Dictionary<string, string> carDictionary = new Dictionary<string, string>();

            for (int i = 0; i < array.Length; i++)
            {
                string car = array[i];

                if (!carDictionary.ContainsKey(car))
                {
                    switch (car)
                    {
                        case "Audi":
                        case "BMW":
                        case "Mercedes":
                        case "Volkswagen":
                            carDictionary.Add(car, "Germany");
                            break;

                        case "Honda":
                            carDictionary.Add(car, "Japan");
                            break;

                        case "Tesla":
                            carDictionary.Add(car, "USA");
                            break;

                        default:
                            carDictionary.Add(car, "");
                            break;
                    }
                }
            }

            foreach (string key in carDictionary.Keys)
            {
                Console.WriteLine($"Car: {key} | Origin: {carDictionary[key]}");
            }

            Console.ReadKey();
        }
    }
}
