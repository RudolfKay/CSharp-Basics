using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BmiCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter your weight(kg):");
            int weightKilos = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please enter your height(cm)");
            double heightCm = Convert.ToDouble(Console.ReadLine());

            double weightPounds = 2.20462262 * weightKilos;
            double heightInches = 0.3937008 * heightCm;

            Console.WriteLine(weightPounds);
            Console.WriteLine(heightInches);
            double bmIndex = weightPounds * 703 / Math.Pow(heightInches, 2);

            if (bmIndex < 18.5)
            {
                Console.WriteLine($"Your BMI is {bmIndex}. You are underweight. ");
            }
            else if (bmIndex > 25)
            {
                Console.WriteLine($"Your BMI is {bmIndex}. You are overweight. ");
            }
            else
            {
                Console.WriteLine($"Your BMI is {bmIndex}. Your weight is within the optimal range. ");
            }

            Console.ReadKey();
        }
    }
}
