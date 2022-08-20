using System;

namespace DragRace
{
    public interface ICar
    {
        void SpeedUp();

        void SlowDown();

        int ShowCurrentSpeed();

        void StartEngine();
    }
}