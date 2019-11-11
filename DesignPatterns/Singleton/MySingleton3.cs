namespace Singleton
{
    // Attempted thread-safety using double-check locking*
    public sealed class MySingleton3
    {
        private static MySingleton3 instance = null;
        private static readonly object padlock = new object();

        private MySingleton3()
        {
        }

        public static MySingleton3 Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new MySingleton3();
                        }
                    }
                }
                return instance;
            }
        }
    }
}
