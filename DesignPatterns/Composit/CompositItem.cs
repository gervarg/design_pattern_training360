using System;
using System.Collections.Generic;
using System.Linq;

namespace Composit
{
    internal class CompositItem : ICompositItem
    {
        private readonly List<IItem> items = new List<IItem>();

        public string Name { get; }

        public decimal Price => items.Sum(item => item.Price);

        public double Mass => items.Sum(item => item.Mass);

        public DateTime ExpirationDate => items.Min(item => item.ExpirationDate);


        public CompositItem(string name)
        {
            Name = name;
        }

        public void Add(IItem item)
        {
            items.Add(item);
        }

        public override string ToString()
        {
            return $"{Name}: {Price}Ft {Mass}g  Lejár ekkor: {ExpirationDate}";
        }
    }
}