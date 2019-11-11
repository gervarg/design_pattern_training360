using System;

namespace LoggerFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            var loggerFactory = LoggerFactory.Instance;
            Console.WriteLine("Hello World!");
        }
    }
}
