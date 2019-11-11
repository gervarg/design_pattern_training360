namespace Bridge
{
    interface IProduct
    {
        string GetDetails();
    }

    class Laptop : IProduct
    {
        private readonly ISettings settings;
        private readonly IPrice price;

        public Laptop(ISettings settings, IPrice price)
        {
            this.settings = settings;
            this.price = price;
        }

        public string GetDetails()
        {
            return $"{this.GetType().Name} {settings.GetSettings()} {price.GetPrice()}";
        }
    }

    class SmartPhone : IProduct
    {
        private readonly ISettings settings;
        private readonly IPrice price;

        public SmartPhone(ISettings settings, IPrice price)
        {
            this.settings = settings;
            this.price = price;
        }

        public string GetDetails()
        {
            return $"{this.GetType().Name} {settings.GetSettings()} {price.GetPrice()}";
        }
    }

    class SmartWatch : IProduct
    {
        private readonly ISettings settings;
        private readonly IPrice price;

        public SmartWatch(ISettings settings, IPrice price)
        {
            this.settings = settings;
            this.price = price;
        }

        public string GetDetails()
        {
            return $"{this.GetType().Name} {settings.GetSettings()} {price.GetPrice()}";
        }
    }
}
