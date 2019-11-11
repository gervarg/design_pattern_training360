using System;

namespace SimpleFactory
{    
    class LogFactory
    {
        private readonly IStackTraceFilter stackTraceFilter;
        private readonly IUserNameProvider userNameProvider;

        public LogFactory(IStackTraceFilter stackTraceFilter, IUserNameProvider userNameProvider)
        {
            this.stackTraceFilter = stackTraceFilter;
            this.userNameProvider = userNameProvider;
        }

        // Do not use static because of tightly-coupling!
        // More difficult to change and test.
        public Log CreateLog(string message, Log.LogLevel level, Exception exception = null)
        {
            return new Log
            {
                Level = level,
                Message = message,
                CreatedAt = DateTime.UtcNow,
                CurrentUser = Environment.CurrentUserName,
                ServerName = Environment.MachineName,
                StackTrace = exception?.StackTrace
            };
            // Info from services
            // Secure stacktrace
        }
    }

    class UserNameProvider : IUserNameProvider
    {
        public string CurrentUserName => Environment.UserName;
    }


    public interface IUserNameProvider
    {
        string CurrentUserName { get; }
    }




    public interface IStackTraceFilter
    {
        string Filter(string stackTrace);
    }

    class StrackTraceFilter : IStackTraceFilter
    {
        public string Filter(string stackTrace)
        {

        }
    }
}
