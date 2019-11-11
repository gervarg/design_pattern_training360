namespace Bridge
{
    interface IPrice
    {
        string GetPrice();
    }

    class EuPrice : IPrice
    {
        public string GetPrice()
        {
            return "with price only for the EU";
        }
    }

    class UsPrice : IPrice
    {
        public string GetPrice()
        {
            return "with price only for the US";
        }
    }
}
