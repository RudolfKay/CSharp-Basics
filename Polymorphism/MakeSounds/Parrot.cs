using System;

namespace MakeSounds
{
    class Parrot : ISound
    {
        public void PlaySound()
        {
            Console.WriteLine("squaaaak-whistle");
        }
    }
}
