using System;

namespace Composit
{
    internal interface IItem
    {
        public decimal Price { get; }

        public double Mass { get; }

        public DateTime ExpirationDate { get; }
    }
}