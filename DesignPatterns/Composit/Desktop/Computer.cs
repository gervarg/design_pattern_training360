using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Composit.Desktop
{
    class Computer : IComputer
    {
        private readonly List<IPart> parts = new List<IPart>();

        public string Name { get; }

        public decimal Price => parts.Sum(part => part.Price);

        public double Consumption => parts.Sum(part => part.Consumption);

        public Computer(string name)
        {
            Name = name;
        }

        public void Add(IPart part)
        {
            parts.Add(part);
        }

        public double EnergyConsumption()
        {
            return parts.Average(part => part.Consumption);
        }
    }
}
