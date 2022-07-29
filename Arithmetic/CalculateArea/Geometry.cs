using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateArea
{
    public class Geometry
    {
        /*  TODO:
         *  A static method that accepts the radius of a circle and returns the area of the circle. Use the following formula:
         *      - Area = π * r * 2
         *      - Use Math.PI for π and r for the radius of the circle
         *      - A static method that accepts the length and width of a rectangle and returns the area of the rectangle.
         *  Use the following formula:
         *      - Area = Length x Width
         *      - A static method that accepts the length of a triangle’s base and the triangle’s height.
         *  The method should return the area of the triangle. Use the following formula:
         *      - Area = Base x Height x 0.5
         *  
         *  The methods should display an error message if negative values are used for the circle’s radius,
         *              the rectangle’s length or width, or the triangle’s base or height.
         */

        public static double AreaOfCircle(decimal radius)
        {
            if (radius <= 0)
            {
                Console.WriteLine($"ERROR -> radius is zero or negative");
                return 0;
            }
            else
            {
                return Math.PI * (double)radius * 2;
            }
        }

        public static double AreaOfRectangle(decimal length, decimal width)
        {
            if (length <= 0 || width <= 0)
            {
                Console.WriteLine($"ERROR -> length and/or width is zero or negative");
                return 0;
            }
            else
            {
                return (double)length * (double)width;
            }
        }

        public static double AreaOfTriangle(decimal ground, decimal h)
        {
            if (ground <= 0 || h <= 0)
            {
                Console.WriteLine($"ERROR -> base and/or height is zero or negative");
                return 0;
            }
            else
            {
                return ((double)ground + (double)h) * 0.5;
            }
        }
    }
}
