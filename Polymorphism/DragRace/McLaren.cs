using System;

namespace DragRace
{
    class McLaren : ICar
    {
        public int _currentSpeed = 0;

        public void SpeedUp()
        {
            _currentSpeed += 4;
        }

        public void SlowDown()
        {
            _currentSpeed -= 3;
        }

        public int ShowCurrentSpeed()
        {
            return _currentSpeed;
        }

        public void StartEngine()
        {
            Console.WriteLine("Rrrrrrr.....");
        }
    }
}
