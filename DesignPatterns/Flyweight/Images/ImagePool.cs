using System.Collections.Generic;

namespace Flyweight
{
    internal class ImagePool // aka Factory, Cache
    {
        private readonly Dictionary<string, Image> cache = new Dictionary<string, Image>();

        internal Image GetImage(string imageName)
        {
            if (!cache.ContainsKey(imageName))
            {
                cache.Add(imageName, new Image(imageName));
            }
            return cache[imageName];
        }
    }
}