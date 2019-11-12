using System;
using System.Collections.Generic;
using System.Text;

namespace Flyweight.Music
{
    class Sound
    {
        public string SoundSymbol { get; }

        private readonly byte[] realsound = new byte[10000];

        public Sound(string sound)
        {
            SoundSymbol = sound;            
        }

        public void MakeSound()
        {
            Console.WriteLine(SoundSymbol);
        }
    }
}
