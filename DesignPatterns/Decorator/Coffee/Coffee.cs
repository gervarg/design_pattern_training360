namespace Decorator
{
    interface ICoffee
    {
        int Cost { get; }
        string Description { get; }
    }

    class SimpleCoffee : ICoffee
    {
        public int Cost { get; } = 10;
        public string Description { get; } = "Simple coffee";
    }

    class MilkCoffee : ICoffee
    {
        protected ICoffee Coffee { get; }

        public int Cost { get { return Coffee.Cost + 2; } }

        public string Description { get { return Coffee.Description + ", milk"; } }

        public MilkCoffee(ICoffee coffee)
        {
            Coffee = coffee;
        }
    }

    class WhippedCoffee : ICoffee
    {
        protected ICoffee Coffee { get; }

        public int Cost { get { return Coffee.Cost + 5; } }

        public string Description { get { return Coffee.Description + ", whip"; } }

        public WhippedCoffee(ICoffee coffee)
        {
            Coffee = coffee;
        }
    }

    class VanillaCoffee : ICoffee
    {
        protected ICoffee Coffee { get; }

        public int Cost { get { return Coffee.Cost + 3; } }

        public string Description { get { return Coffee.Description + ", vanilla"; } }

        public VanillaCoffee(ICoffee coffee)
        {
            Coffee = coffee;
        }
    }
}
