using System;

namespace Command
{
    // Receiver
    class Bulb
    {
        public void TurnOn()
        {
            Console.WriteLine("Bulb has been lit!");
        }

        public void TurnOff()
        {
            Console.WriteLine("Darkness!");
        }
    }

    // The command interface
    interface ILightBulbCommand
    {
        void Execute();
        void Undo();
        void Redo();
    }

    // Concrete command
    class TurnOn : ILightBulbCommand
    {
        protected readonly Bulb _bulb;

        public TurnOn(Bulb bulb)
        {
            _bulb = bulb;
        }

        public void Execute()
        {
            _bulb.TurnOn();
        }

        public void Undo()
        {
            _bulb.TurnOff();
        }

        public void Redo()
        {
            Execute();
        }
    }

    // Concrete command
    class TurnOff : ILightBulbCommand
    {
        protected readonly Bulb _blub;

        public TurnOff(Bulb bulb)
        {
            _blub = bulb;
        }

        public void Execute()
        {
            _blub.TurnOff();
        }

        public void Undo()
        {
            _blub.TurnOn();
        }

        public void Redo()
        {
            Execute();
        }
    }

    // Invoker with whom the client will interact to process any commands.
    class RemoteControl
    {
        public void Submit(ILightBulbCommand command)
        {
            command.Execute();
        }
    }
}
