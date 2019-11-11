using System;

namespace Command
{
    interface ILoadDataCommand
    {        
        void Execute();
    }

    class LoadDataFromDatabaseCommand : ILoadDataCommand
    {
        private readonly string connectionString;

        public LoadDataFromDatabaseCommand(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Execute()
        {
            Console.WriteLine("Loading data from database...");

            // Tip: T Result { get; }
        }
    }

    class LoadDataFromWebserviceCommand : ILoadDataCommand
    {
        private readonly string url;

        public LoadDataFromWebserviceCommand(string url)
        {
            this.url = url;
        }

        public void Execute()
        {
            Console.WriteLine("Loading data from webservice...");
        }
    }

    class LoadDataFromFileCommand : ILoadDataCommand
    {
        private readonly string fileName;

        public LoadDataFromFileCommand(string fileName)
        {
            this.fileName = fileName;
        }

        public void Execute()
        {
            Console.WriteLine("Loading data from file...");
        }
    }


    class LoadDataCommandFactory
    {
        internal static ILoadDataCommand GetCommand(string from, string parameter)
        {
            if (from == "db") return new LoadDataFromDatabaseCommand(connectionString: parameter);
            else if (from == "web") return new LoadDataFromWebserviceCommand(url: parameter);
            else if (from == "file") return new LoadDataFromFileCommand(fileName: parameter);
            else throw new Exception("Unsupported command type!");
        }
    }
}
