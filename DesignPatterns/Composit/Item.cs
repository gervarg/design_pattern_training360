using System;

namespace Composit
{
    internal class Item : IItem
    {
        public string Name { get; }
        public decimal Price { get; }
        public double Mass { get; }
        public DateTime ExpirationDate { get; }

        public Item(string name, decimal price, double mass, DateTime expDate)
        {
            Name = name;
            Price = price;
            Mass = mass;
            ExpirationDate = expDate;
        }

        public override string ToString()
        {
            return $"{Name}: {Price}Ft {Mass}g  Lejár ekkor: {ExpirationDate}";
        }
    }
}