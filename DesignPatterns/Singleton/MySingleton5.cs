namespace Singleton
{
    // Fully lazy instantiation
    public sealed class MySingleton5
    {
        private MySingleton5()
        {
        }

        public static MySingleton5 Instance 
        { 
            get 
            {                 
                return Nested.Instance; 
            } 
        }

        private class Nested
        {
            // Explicit static constructor to tell C# compiler not to mark type as beforefieldinit
            static Nested()
            {
            }

            internal static readonly MySingleton5 Instance = new MySingleton5();
        }
    }
}
