using System;
using System.Collections.Generic;
using System.Text;

namespace BankProject
{
    interface ILoggerService
    {
        void Log(string message);
    }

    class LoggerService : ILoggerService
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
