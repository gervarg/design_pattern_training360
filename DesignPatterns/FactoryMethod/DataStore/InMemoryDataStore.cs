using System.IO;

namespace FactoryMethod
{
    internal class InMemoryDataStore : DataStore
    {
        private readonly byte[] data = new byte[1024];

        protected override Stream GetStream()
        {           
            return new MemoryStream(data);
        }
    }
}