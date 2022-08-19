using System;

namespace Exercise8
{
    class Program
    {
        static void Main(string[] args)
        {
            Point p1 = new Point(5, 2);
            Point p2 = new Point(-3, 6);

            SwapPoints(p1, p2);

            Console.WriteLine("(" + p1.x + ", " + p1.y + ")");
            Console.WriteLine("(" + p2.x + ", " + p2.y + ")");

            Console.ReadKey();
        }

        public static void SwapPoints(Point p1, Point p2)
        {
            Point placeHolder = new Point(p1.x, p1.y);

            p1.EditCoordinates(p2.x, p2.y);
            p2.EditCoordinates(placeHolder.x, placeHolder.y);
        }
    }
}
