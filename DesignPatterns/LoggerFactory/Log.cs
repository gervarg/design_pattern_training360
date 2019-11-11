using System;

namespace LoggerFactory
{
    class Log
    {
        public DateTime CreatedAt { get; set; }

        public LogLevel Level { get; set; }

        public string Message { get; set; }

        
        // Environment details

        public string CurrentUser { get; set; }
        
        public string ServerName { get; set; }


        // Exception details
        public string StackTrace { get; set; }


        public override string ToString()
        {
            return $"{CreatedAt} {Level} {Message} {CurrentUser} {ServerName} {StackTrace}";
        }


        public enum LogLevel
        {
            Trace = 0, 
            Debug = 1, 
            Info = 2, 
            Warn = 3, 
            Error = 4, 
            Fatal = 5
        }
    }
}
