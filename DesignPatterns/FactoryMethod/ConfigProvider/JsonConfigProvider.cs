namespace FactoryMethod
{
    internal class JsonConfigProvider : IConfigProvider
    {
        public override string ToString()
        {
            return "Read config values from JSON file.";
        }
    }
}