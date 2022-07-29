using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateArea
{
    class Program
    {
        static void Main(string[] args)
        {
            int userChoice = GetMenu();

            switch (userChoice)
            {
                case 1:
                    CalculateCircleArea();
                    break;
                case 2:
                    CalculateRectangleArea();
                    break;
                case 3:
                    CalculateTriangleArea();
                    break;
                default:
                    Console.WriteLine("Quitting...");
                    Console.ReadKey();
                    break;
            }
        }

        public static int GetMenu()
        {
            string userChoice;
            int numCheck = 0;
            
            Console.WriteLine("Geometry Calculator\n");
            Console.WriteLine("1. Calculate the Area of a Circle");
            Console.WriteLine("2. Calculate the Area of a Rectangle");
            Console.WriteLine("3. Calculate the Area of a Triangle");
            Console.WriteLine("4. Quit\n");
            Console.WriteLine("Enter your choice (1-4) : ");
            userChoice = Console.ReadLine();
            
            while (string.IsNullOrEmpty(userChoice) || !int.TryParse(userChoice , out numCheck)
                   || int.Parse(userChoice) < 1 || int.Parse(userChoice) > 4)
            {
                Console.WriteLine("Input invalid or missing. Try again!");
                userChoice = Console.ReadLine();
            }

            return Convert.ToInt32(userChoice);
        }

        public static void CalculateCircleArea()
        {
            Console.WriteLine("What is the circle's radius? ");
            decimal radius = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("The circle's area is "
                    + Geometry.AreaOfCircle(radius));
            Console.ReadKey();
        }

        public static void CalculateRectangleArea()
        {
            decimal length = 0;
            decimal width = 0;

            Console.WriteLine("Enter length? ");
            length = Convert.ToDecimal(Console.ReadLine());
            
            Console.WriteLine("Enter width? ");
            width = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("The rectangle's area is "
                              + Geometry.AreaOfTriangle(length, width));
            Console.ReadKey();
        }

        public static void CalculateTriangleArea()
        {
            decimal ground = 0;
            decimal height = 0;

            Console.WriteLine("Enter length of the triangle's base? ");
            ground = Convert.ToDecimal(Console.ReadLine());
            
            Console.WriteLine("Enter triangle's height? ");
            height = Convert.ToDecimal(Console.ReadLine());
            
            Console.WriteLine("The triangle's area is "
                    + Geometry.AreaOfRectangle(ground, height));
            Console.ReadKey();
        }
    }
}
