using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateArea
{
    public class Geometry
    {
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
