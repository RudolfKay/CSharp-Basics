using System;

namespace DragRace
{
    public class Lexus : ICar, INitrous
    {
        public int _currentSpeed = 0;

        public void SpeedUp() 
        {
            _currentSpeed += 2;
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