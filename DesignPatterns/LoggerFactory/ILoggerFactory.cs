using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerFactory
{
    interface ILoggerFactory
    {
        Log GetLogger();      
    }
}
