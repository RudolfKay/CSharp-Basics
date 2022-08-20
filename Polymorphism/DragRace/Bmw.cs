using System;

namespace DragRace
{
    public class Bmw : ICar
    {
        public int _currentSpeed = 0;

        public void SpeedUp() 
        {
            _currentSpeed += 2;
        }

        public void SlowDown() 
        {
            _currentSpeed -= 2;
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