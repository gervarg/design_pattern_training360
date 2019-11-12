using System;
using System.Collections.Generic;
using System.Text;

namespace Flyweight.Music
{
    class SoundFactory
    {
        private readonly Dictionary<string, Sound> cache = new Dictionary<string, Sound>();

        internal Sound GetSound(string soundSymbol)
        {
            if (!cache.ContainsKey(soundSymbol))
            {
                cache.Add(soundSymbol, new Sound(soundSymbol));
            }
            return cache[soundSymbol];
        }
    }
}
