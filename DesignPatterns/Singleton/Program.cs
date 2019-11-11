using System;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            var mySingleton11 = MySingleton1.Instance;
            var mySingleton12 = MySingleton1.Instance;
            Console.WriteLine(mySingleton11 == mySingleton12);


            var mySingleton21 = MySingleton2.Instance;
            var mySingleton22 = MySingleton2.Instance;
            Console.WriteLine(mySingleton21 == mySingleton22);


            var mySingleton31 = MySingleton3.Instance;
            var mySingleton32 = MySingleton3.Instance;
            Console.WriteLine(mySingleton31 == mySingleton32);


            var mySingleton41 = MySingleton4.Instance;
            var mySingleton42 = MySingleton4.Instance;
            Console.WriteLine(mySingleton41 == mySingleton42);


            var mySingleton51 = MySingleton5.Instance;
            var mySingleton52 = MySingleton5.Instance;
            Console.WriteLine(mySingleton51 == mySingleton52);


            var mySingleton61 = MySingleton6.Instance;
            var mySingleton62 = MySingleton6.Instance;
            Console.WriteLine(mySingleton61 == mySingleton62);

            //
            // +1
            // Singleton pattern is considered an anti-pattern and overuse of it should be avoided. 
            // It is not necessarily bad and could have some valid use-cases but should be used with caution 
            // because it introduces a global state in your application and change to it in one place 
            // could affect in the other areas and it could become pretty difficult to debug. 
            // It makes your code tightly coupled and mocking the singleton could be difficult.
            // => solution: use DI with singleton lifetime settings!
            //
        }
    }
}
