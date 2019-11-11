namespace Singleton
{
    // simple thread-safety   
    public sealed class MySingleton2
    {
        private static MySingleton2 instance = null;

        // wherever possible, only lock on objects specifically created for the purpose of locking
        private static readonly object padlock = new object();

        private MySingleton2()
        {
        }

        public static MySingleton2 Instance
        {
            get
            {
                // Unfortunately, performance suffers as a lock is acquired every time the instance is requested. 
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new MySingleton2();
                    }
                    return instance;
                }
            }
        }
    }
}
