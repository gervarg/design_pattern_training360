namespace Singleton
{
    // not thread-safe
    public sealed class MySingleton1
    {
        private static MySingleton1 instance = null;

        private MySingleton1()
        {
        }

        public static MySingleton1 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MySingleton1();
                }
                return instance;
            }
        }
    }
}
