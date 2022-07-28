using System;

namespace MoreVariablesAndPrinting
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "Zed A. Shaw";
            string eyes = "Blue";
            string teeth = "White";
            string hair = "Brown";
            int age = 35;
            int height = 74;  // inches
            int weight = 180; // lbs
            double heightCm = Math.Round(height * 2.54 , 2);
            double weightKg = Math.Round(weight * 0.453592 , 2);
            
            Console.WriteLine("Let's talk about " + name + ".");
            Console.WriteLine("He's " + heightCm + " centimeters tall.");
            Console.WriteLine("He's " + weightKg + " kilograms heavy.");
            Console.WriteLine("Actually, that's not too heavy.");
            Console.WriteLine("He's got " + eyes + " eyes and " + hair + " hair.");
            Console.WriteLine("His teeth are usually " + teeth + " depending on the coffee.");
            Console.WriteLine("If I add " + age + ", " + heightCm + ", and " + weightKg
                              + " I get " + (age + heightCm + weightKg) + ".");
            Console.ReadKey();
        }
    }
}