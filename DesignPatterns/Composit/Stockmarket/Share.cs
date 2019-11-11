namespace Composit
{
    internal class Share : IShare
    {
        private readonly string name;

        public Share(string name, decimal price)
        {
            this.name = name;
            this.Price = price;
        }

        public decimal Price { get; }

        public override string ToString()
        {
            return $"{name}: {Price}";
        }
    }
}