using System;
using System.Collections.Generic;

namespace Prototype
{
    // Summary:
    // It's all about cloning and saving effort. Do not pay twice!
    class Program
    {
        static void Main(string[] args)
        {            
            LaptopExample();
            //ComplexShapeExample();
        }

        private static void ComplexShapeExample()
        {
            var shape1 = new ComplexShape();
            Console.WriteLine(shape1);

            var shape2 = shape1.Clone() as ComplexShape;
            Console.WriteLine(shape2);

            shape1.Move(10, 20, 30);
            Console.WriteLine(shape1);

            shape2.Move(-20, -25, 100);
            Console.WriteLine(shape2);
        }

        private static void LaptopExample()
        {
            var basicLatop = new Laptop()
            {
                Model = "BASIC",
                Monitor = "1366x768",
                Cpu = "i5-4200U",
                Rams = new List<string> { "DDR3-4GB" },
                Drives = new List<string> { "HDD-1TB" },
                Ports = new List<string> { "USB 2.0", "USB 2.0", "USB 3.0", "HDMI", "CardReader", "Ethernet", "Voice", "Electricity" },
                Keyboard = "Hungarian"
            };

            Console.WriteLine(basicLatop);


            var devLaptop = basicLatop.Clone() as Laptop;
            devLaptop.Model = "DEV";
            devLaptop.Cpu = "i7-8250U";
            devLaptop.Rams.Add("DDR3-8GB");
            devLaptop.Drives.Add("SSD-512GB");

            Console.WriteLine(basicLatop);
            Console.WriteLine(devLaptop);
        }
    }
}
