using System;

namespace Exercise13
{
    class Program
    {
        static void Main(string[] args)
        {
            Smoothie s1 = new Smoothie(new string[] { "Banana" });
            Console.WriteLine(s1.Ingredients); // ➞ { "Banana" }

            Console.WriteLine(s1.GetCost()); // ➞ "£0.50"
            Console.WriteLine(s1.GetPrice()); // ➞ "£1.25"
            Console.WriteLine(s1.GetName()); // ➞ "Banana Smoothie"

            Smoothie s2 = new Smoothie(new string[] { "Raspberries", "Strawberries", "Blueberries" });
            Console.WriteLine(s2.Ingredients); // ➞ { "Raspberries", "Strawberries", "Blueberries" }

            Console.WriteLine(s2.GetCost()); // ➞ "£3.50"
            Console.WriteLine(s2.GetPrice()); // ➞ "£8.75"
            Console.WriteLine(s2.GetName()); // ➞ "Blueberry Raspberry Strawberry Fusion";
        
            Console.ReadKey();
        }
    }
}
