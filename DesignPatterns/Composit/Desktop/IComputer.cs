using System;
using System.Collections.Generic;
using System.Text;

namespace Composit.Desktop
{
    interface IComputer: IPart
    {
        void Add(IPart part);

        double EnergyConsumption();
    }
}
