using System;

namespace DragRace
{
    class Buick : ICar , INitrous
    {
        public int _currentSpeed = 0;

        public void SpeedUp()
        {
            _currentSpeed++;
        }

        public void SlowDown()
        {
            _currentSpeed--;
        }

        public void UseNitrousOxideEngine()
        {
            _currentSpeed += 4;
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
