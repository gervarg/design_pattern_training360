using System;
using System.Collections.Generic;
using System.Text;

namespace Composit.Desktop
{
    class Part : IPart
    {
        public string Name { get; }
        public decimal Price { get; }
        public double Consumption { get; }

        public Part(string name, decimal price, double consumption)
        {
            Name = name;
            Price = price;
            Consumption = consumption;
        }

        public override string ToString()
        {
            return $"{Name}: {Price}Ft Fogyasztas: {Consumption}";
        }
    }
}
