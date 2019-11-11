namespace AbstractFactory
{
    internal abstract class DbConection
    {
        public abstract void Open();

        public abstract void Close();
    }
}