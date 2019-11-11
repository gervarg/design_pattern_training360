using System;
using System.Threading;

namespace Prototype
{
    class ComplexShape : ICloneable
    {       
        public (int, int, int) Center { get; private set; } = (0, 0, 0);

        public ComplexShape()
        {
            Console.Write("Calculating a very complex 3D shape...");
            Thread.Sleep(5000);
            Console.WriteLine("done.");
        }

        public void Move(int x, int y, int z)
        {
            Center = (x, y, z);
        }

        public override string ToString()
        {
            return $"{GetHashCode()} - {Center}";
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
