using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerFactory
{
        internal class LoggerFactories
        {
            internal static ILoggerFactory GetFactory(string code)
            {
                if (code == "xml")
                {
                    return new XmlLoggerFactory();
                }
                else if (code == "json")
                {
                    return new JsonLoggerFactory();
                }
                else if (code == "general")
                {
                return new GeneralLoggerFactory();                
                }
                else
            {
                throw new Exception($"Unknown code: {code}");
            }
            }
        }
    
}
