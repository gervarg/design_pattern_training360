using System.IO;

namespace FactoryMethod
{
    internal class FileDataStore : DataStore
    {
        protected override Stream GetStream()
        {            
            return new FileStream("data", FileMode.OpenOrCreate, FileAccess.ReadWrite); ;
        }
    }
}