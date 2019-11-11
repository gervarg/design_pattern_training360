using System;

namespace Strategy
{
    class SzjaKalkulátor
    {
        private readonly ISzjaTörvény szjaTörvény;

        public SzjaKalkulátor(ISzjaTörvény szjaTörvény)
        {
            this.szjaTörvény = szjaTörvény;
        }

        public decimal Kiszámít(decimal bruttóFizetés)
        {
            return szjaTörvény.Kiszámít(bruttóFizetés);
        }
    }

    interface ISzjaTörvény
    {
        decimal Kiszámít(decimal bruttóFizetés);
    }

    class SzjaTörvény2019 : SzjaTörvény2016 { }
    class SzjaTörvény2018 : SzjaTörvény2016 { }
    class SzjaTörvény2017 : SzjaTörvény2016 { }

    class SzjaTörvény2016 : ISzjaTörvény
    {
        public decimal Kiszámít(decimal bruttóFizetés)
        {
            if (bruttóFizetés < 0)
            {
                throw new Exception("A bruttó fizetés nem lehet kisebb mint 0!");
            }
            return bruttóFizetés * (decimal)0.15;
        }
    }

    class SzjaTörvény2015 : ISzjaTörvény
    {
        public decimal Kiszámít(decimal bruttóFizetés)
        {
            if (bruttóFizetés < 0)
            {
                throw new Exception("A bruttó fizetés nem lehet kisebb mint 0!");
            }
            return bruttóFizetés * (decimal)0.16;
        }
    }

    class FiktívKétkulcsosSzjaTörvény : ISzjaTörvény
    {
        public decimal Kiszámít(decimal bruttóFizetés)
        {
            if (bruttóFizetés < 0)
            {
                throw new Exception("A bruttó fizetés nem lehet kisebb mint 0!");
            }
            if (bruttóFizetés < 300_000)
            {
                return bruttóFizetés * (decimal)0.12;
            }
            else
            {
                return bruttóFizetés * (decimal)0.25;
            }
        }
    }
}
