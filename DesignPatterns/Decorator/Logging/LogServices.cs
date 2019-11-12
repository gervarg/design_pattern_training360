using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator.Logging
{
    public interface ILogService
    {
        void Log(string message);
    }

    class LogService : ILogService
    {
        List<string> messages = new List<string>();

        public void Log(string message)
        {
            messages.Add(message);
            Console.WriteLine(messages);
        }
    }

    class FilteredLoggingService : ILogService
    {
        private readonly ILogService logservice; 

        public FilteredLoggingService(ILogService service)
        {
            this.logservice = service;
        }

        public void Log(string message)
        {
            foreach (string item in logservice.messages)
            {
                if(item.Contains(Environment.UserName))
                {
                    item.Replace
                }
            }
        }
    }

    // TODO Pass Logs list to other implementations

    class BufferedLoggingService : ILogService
    {
        private readonly ILogService logservice;
        public BufferedLoggingService(ILogService service)
        {
            this.logservice = service;
        }

        public void Log(string message)
        {
           if(logservice.messages.length == 10)
            {
                Console.WriteLine(logservice.messages);
            }
        }
    }
}
