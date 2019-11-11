namespace Builder
{
    class Burger
    {
        public int Size { get; }
        public bool Cheese { get; }
        public bool Pepperoni { get; }
        public bool Lettuce { get; }
        public bool Tomato { get; }

        public Burger(BurgerBuilder builder)
        {
            Size = builder.Size;
            Cheese = builder.Cheese;
            Pepperoni = builder.Pepperoni;
            Lettuce = builder.Lettuce;
            Tomato = builder.Tomato;
        }

        // telescoping constructor anti-pattern
        public Burger(int size, bool cheese = true, bool pepperoni = true, bool tomato = false, bool lettuce = true)
        {
        }

        public override string ToString()
        {
            return $"Burger with size {Size} {(Cheese ? "+cheese" : "")} {(Pepperoni ? "+pepperoni" : "")} {(Lettuce ? "+lettuce" : "")} {(Tomato ? "+tomato" : "")}";
        }
    }

    class BurgerBuilder
    {
        public int Size { get; }
        public bool Cheese { get; private set; }
        public bool Pepperoni { get; private set; }
        public bool Lettuce { get; private set; }
        public bool Tomato { get; private set; }

        public BurgerBuilder(int size)
        {
            Size = size;
        }

        public BurgerBuilder AddPepperoni()
        {
            Pepperoni = true;
            return this;
        }

        public BurgerBuilder AddLettuce()
        {
            Lettuce = true;
            return this;
        }

        public BurgerBuilder AddCheese()
        {
            Cheese = true;
            return this;
        }

        public BurgerBuilder AddTomato()
        {
            Tomato = true;
            return this;
        }

        public Burger Build()
        {
            return new Burger(this);
        }
    }
}
