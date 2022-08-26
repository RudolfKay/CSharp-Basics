using System;

namespace DragRace
{
    public class Tesla : ICar
    {
        public int _currentSpeed = 0;

        public void SpeedUp() 
        {
            _currentSpeed += 3;
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
            Console.WriteLine("--- silence ---");
        }
    }
}