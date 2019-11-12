using System;
using System.Collections.Generic;
using System.Text;

namespace Composit.Desktop
{
    interface IPart
    {
        public decimal Price { get; }

        public double Consumption { get; }
    }
}
