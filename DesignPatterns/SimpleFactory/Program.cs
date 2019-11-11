using System;

namespace SimpleFactory
{
    // Summary
    // The Simple Factory pattern enables the creation of objects 
    // without exposing the instantiation logic to the client.
    class Program
    {
        static void Main(string[] args)
        {
            var logFactory = new LogFactory(new StrackTraceFilter(), new UserNameProvider());
            Log log = logFactory.CreateLog("App started!", Log.LogLevel.Info);
            
            Console.WriteLine(log);
        }
    }
}
