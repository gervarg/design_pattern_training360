using System;
using System.IO;

namespace Flyweight
{
    internal class ChemicalElement
    {        
        public ChemicalElement(string chemicalSymbol)
        {
            ChemicalSymbol = chemicalSymbol;

            Image = Convert.ToBase64String(File.ReadAllBytes("blue.bmp"));
        }

        public string ChemicalSymbol { get; }

        public string Image { get; set; }
    }
}