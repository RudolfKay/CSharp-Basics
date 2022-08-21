using System;

namespace MakeSounds
{
    class Radio : ISound
    {
        public void PlaySound()
        {
            Console.WriteLine("never gonna give you up, never gonna let you down...");
        }
    }
}
