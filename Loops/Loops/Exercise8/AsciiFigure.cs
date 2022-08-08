using System;

namespace Exercise8
{
    public class AsciiFigure
    {
        int _figureSize;

        public AsciiFigure(int size)
        {
            _figureSize = size;
        }

        public void DrawFigure()
        {
            Console.WriteLine($" Drawing figure of size {_figureSize}\n---------------------------\n");

            int halfRowLength = _figureSize - 1;
            int slashMultiplier = 4;            //Number by which to multiply / and \ chars
            int numOfSides = 2;
            int starBase = 8;                   //Number of stars starting with first row

            for (int i = 0; i < _figureSize; i++)
            {
                string middle = new string('*', (i * starBase));
                string leftSide = new string('/', slashMultiplier * (halfRowLength));
                string rightSide = new string('\\', slashMultiplier * (halfRowLength));

                if (middle.Length != 0)
                {
                    leftSide = new string('/', slashMultiplier * halfRowLength - (middle.Length / numOfSides));
                    rightSide = new string('\\', slashMultiplier * halfRowLength - (middle.Length / numOfSides));
                }
                
                Console.WriteLine(leftSide + middle + rightSide);
            }

            Console.ReadKey();
        }
    }
}
