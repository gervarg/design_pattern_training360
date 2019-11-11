using System;

namespace Bridge
{
    class Program
    {
        // Summary:
        // Bridge pattern is about preferring composition over inheritance. 
        // Implementation details are pushed from a hierarchy to another object with a separate hierarchy.
        //
        // Objektumok különféle változatainak létrehozása kompozícióval, származtatás helyett.
        static void Main(string[] args)
        {
            // 1. Create webpages with different colors!

            //var about = new About(new DarkTheme());
            //var careers = new Careers(new AquaTheme());

            //Console.WriteLine("Create webpages with different colors!");
            //Console.WriteLine(about.GetContent());
            //Console.WriteLine(careers.GetContent());
            //Console.WriteLine();


            // 2. Create products with different settings, prices

            var laptop = new Laptop(new EnglishSettings(), new EuPrice());
            var smartPhone = new SmartPhone(new HungarianSettings(), new EuPrice());
            var smartWatch = new SmartWatch(new EnglishSettings(), new UsPrice());

            Console.WriteLine("Create products with different settings, prices!");
            Console.WriteLine(laptop.GetDetails());
            Console.WriteLine(smartPhone.GetDetails());
            Console.WriteLine(smartWatch.GetDetails());
            Console.WriteLine();
        }
    }
}
