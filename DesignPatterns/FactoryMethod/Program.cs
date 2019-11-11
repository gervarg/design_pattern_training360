using System;

namespace FactoryMethod
{
    // Summary:
    // The Factory Method pattern enables the creation of objects 
    // without specifing the exact type of the objects.
    class Program
    {
        static void Main(string[] args)
        {
            // 1.
            IConfigProvider configProvider = ConfigProviderFactrory.GetConfigProvider(ConfigProvider.Json);
            Console.WriteLine(configProvider);


            // 2.
            var parserFactory = new ParserFactory();
            IParser parser = parserFactory.GetParser("file.xml");
            Console.WriteLine(parser.GetType());


            // 3.
            DataStore fileDataStore = new FileDataStore();
            //DataStore fileDataStore = new InMemoryDataStore();
            fileDataStore.Write("Hello World!");
            Console.WriteLine(fileDataStore.Read());            
        }
    }
}
