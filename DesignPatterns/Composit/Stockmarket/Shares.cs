using System.Collections.Generic;
using System.Linq;

namespace Composit
{
    internal class Shares : IShares
    {
        private readonly string name;
        private readonly List<IShare> shares = new List<IShare>();

        public Shares(string name)
        {
            this.name = name;
        }
        
        public void Add(IShare share)
        {
            shares.Add(share);
        }

        public decimal Price => shares.Sum(share => share.Price);

        public override string ToString()
        {
            return $"{name}: {Price}";
        }
    }
}