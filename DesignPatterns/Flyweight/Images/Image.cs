using System.IO;

namespace Flyweight
{
    internal class Image
    {
        private readonly byte[] content;

        public Image(string name)
        {
            content = File.ReadAllBytes(name);   
        }

        public string Name { get; }
    }
}