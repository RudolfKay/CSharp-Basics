using System;

namespace Exercise8
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            int drawSize = 13;

            AsciiFigure pyramid = new AsciiFigure(drawSize);
            pyramid.DrawFigure();
        }
    }
}
