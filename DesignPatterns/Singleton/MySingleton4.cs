namespace Singleton
{
    // not quite as lazy, but thread-safe without using locks
    public sealed class MySingleton4
    {
        private static readonly MySingleton4 instance = new MySingleton4();

        // Static constructors in C# are specified to execute 
        // * only when an instance of the class is created 
        // * or a static member is referenced, 
        // * and to execute only once per AppDomain. 

        // The laziness of type initializers is only guaranteed by .NET 
        // when the type isn't marked with a special flag called beforefieldinit.
        // The C# compiler marks all types which don't have a static constructor as beforefieldinit.
        // Add an explicit static constructor to tell C# compiler not to mark type as beforefieldinit.
        static MySingleton4()
        {
        }

        private MySingleton4()
        {
        }

        public static MySingleton4 Instance
        {
            get
            {
                return instance;
            }
        }
    }
}
