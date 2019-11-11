using System;

namespace Facade
{
    class ComputerFacade
    {
        protected Computer Computer;

        public ComputerFacade(Computer computer)
        {
            Computer = computer;
        }

        public void TurnOn()
        {
            Console.WriteLine("Turn computer ON");
            Computer.GetElectricShock();
            Computer.MakeSound();
            Computer.ShowLoadingScreen();
            Computer.Bam();
            Console.WriteLine();
        }

        public void TurnOff()
        {
            Console.WriteLine("Turn computer OFF");
            Computer.CloseEverything();
            Computer.PullCurrent();
            Computer.Sooth();
            Console.WriteLine();
        }
    }


    class Computer
    {
        public void GetElectricShock()
        {
            Console.WriteLine("Ouch!");
        }

        public void MakeSound()
        {
            Console.WriteLine("Beep beep!");
        }

        public void ShowLoadingScreen()
        {
            Console.WriteLine("Loading..");
        }

        public void Bam()
        {
            Console.WriteLine("Ready to be used!");
        }

        public void CloseEverything()
        {
            Console.WriteLine("Bup bup bup buzzzz!");
        }

        public void Sooth()
        {
            Console.WriteLine("Zzzzz");
        }

        public void PullCurrent()
        {
            Console.WriteLine("Haaah!");
        }
    }    
}
