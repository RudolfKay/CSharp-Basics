using System;
using System.Collections.Generic;

namespace MakeSounds
{
    class Program
    {
        private static void Main(string[] args)
        {
            ISound fireworks = new Firework();
            ISound parrot = new Parrot();
            ISound radio = new Radio();

            List<ISound> sounds = new List<ISound>() { fireworks, parrot, radio, parrot, fireworks, radio };

            foreach (ISound sound in sounds)
            {
                sound.PlaySound();
            }

            Console.ReadKey();
        }
    }
}