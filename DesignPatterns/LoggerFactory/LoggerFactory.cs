using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerFactory
{
    public sealed class LoggerFactory
    {

        private static LoggerFactory instance = null;

        private LoggerFactory(string loggerType)
        {
            ILoggerFactory factoryType = new LoggerFactories(loggerType);
        }

        public static LoggerFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LoggerFactory(string logger);
                }
                return instance;
            }
        }
    }
}
