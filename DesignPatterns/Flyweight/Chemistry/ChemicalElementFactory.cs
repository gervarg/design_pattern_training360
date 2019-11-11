using System.Collections.Generic;

namespace Flyweight
{
    internal class ChemicalElementFactory
    {
        private readonly Dictionary<string, ChemicalElement> cache = new Dictionary<string, ChemicalElement>();

        internal ChemicalElement GetChemicalElement(string chemicalSymbol)
        {
            if (!cache.ContainsKey(chemicalSymbol))
            {
                cache.Add(chemicalSymbol, new ChemicalElement(chemicalSymbol));
            }
            return cache[chemicalSymbol];
        }
    }
}