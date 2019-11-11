using System.IO;

namespace FactoryMethod
{
    internal class ParserFactory
    {
        internal IParser GetParser(string fileName)
        {
            string extension = Path.GetExtension(fileName)?.ToLower();

            if (extension == ".xml")
            {
                return new XmlParser();
            }
            else if (extension == ".json")
            {
                return new JsonParser();
            }
            else
            {
                return new GeneralParser();
            }
        }
    }
}