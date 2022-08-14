using System;

namespace Exercise8
{
    class Point
    {
        private int _x;
        private int _y;

        public int x => _x;
        public int y => _y;

        public Point(int xCoord, int yCoord)
        {
            _x = xCoord;
            _y = yCoord;
        }

        public void EditCoordinates(int newX, int newY)
        {
            _x = newX;
            _y = newY;
        }

    }
}
