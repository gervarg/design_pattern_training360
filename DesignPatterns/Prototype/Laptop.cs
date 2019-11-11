using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prototype
{
    internal class Laptop : ICloneable
    {
        public string Model { get; set; }

        public string Monitor { get; set; }

        public string Cpu { get; set; }

        public List<string> Rams { get; set; }
        
        public List<string> Drives { get; set; }
        
        public List<string> Ports { get; set; }

        public string Keyboard { get; set; }


        public object Clone()
        {
            // Shallow copy
            //return this.MemberwiseClone();

            // Deep copy
            return new Laptop
            {
                Model = Model,
                Monitor = Monitor,
                Cpu = Cpu,
                Rams = Rams.ToList(),
                Drives = Drives.ToList(),
                Ports = Ports.ToList(),
                Keyboard = Keyboard
            };
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"{"Model:",-20}{Model}");
            stringBuilder.AppendLine($"{"Monitor:",-20}{Monitor}");
            stringBuilder.AppendLine($"{"Cpu:",-20}{Cpu}");
            stringBuilder.AppendLine($"{"Rams:",-20}{string.Join(',', Rams)}");
            stringBuilder.AppendLine($"{"Drives:",-20}{string.Join(',', Drives)}");
            stringBuilder.AppendLine($"{"Ports:",-20}{string.Join(',', Ports)}");
            stringBuilder.AppendLine($"{"Keyboard:",-20}{Keyboard}");
            stringBuilder.AppendLine();
            return stringBuilder.ToString();
        }
    }
}