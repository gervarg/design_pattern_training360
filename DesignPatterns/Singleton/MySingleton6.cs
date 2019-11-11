using System;

namespace Singleton
{
    // Using Lazy<T> type: 
    // * .NET 4+
    // * It's simple and performs well.
    public sealed class MySingleton6
    {
        // Press F1 to see the details!        
        private static readonly Lazy<MySingleton6> lazy = new Lazy<MySingleton6>(() => new MySingleton6());

        public static MySingleton6 Instance 
        { 
            get 
            { 
                return lazy.Value; 
            } 
        }

        private MySingleton6()
        {
        }
    }
}
