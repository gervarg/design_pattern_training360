using System.IO;

namespace FactoryMethod
{
    abstract class DataStore
    {
        // Factory method
        protected abstract Stream GetStream();

        public void Write(string data)
        {
            Stream stream = GetStream();
            using var streamWriter = new StreamWriter(stream);
            streamWriter.Write(data);
        }

        public string Read()
        {
            Stream stream = GetStream();
            using var streamReader = new StreamReader(stream);
            return streamReader.ReadToEnd();
        }
    }
}