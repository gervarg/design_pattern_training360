using System;

namespace Command
{
    interface ICommand
    {
        void Execute();

        void Undo();
    }

    class HelpCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("This is a help document about the program.");
        }

        public void Undo()
        {
            Console.WriteLine("Cannot undo this command.");
        }
    }

    class UnknownCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Unknow command.");
        }

        public void Undo()
        {
            Console.WriteLine("Cannot undo this command.");
        }
    }

    class AddCommand : ICommand
    {
        private static int summa = 0;

        private readonly int number;

        private bool canUndo = false;

        public AddCommand(int number)
        {
            this.number = number;
        }

        public void Execute()
        {
            summa += this.number;
            Console.WriteLine($"Summa: {summa}");
            canUndo = true;
        }

        public void Undo()
        {
            if (canUndo)
            {
                summa -= this.number;
                Console.WriteLine($"Summa: {summa}");
                canUndo = false;
            }
            else
            {
                Console.WriteLine("There is nothing to undo!");
            }
        }
    }

    class CommandFactory
    {
        internal ICommand GetCommand(string[] inputs)
        {
            if (inputs.Length == 0)
            {
                throw new ArgumentException("Input array must have at least one value!");
            }

            switch (inputs[0])
            {
                case "help":
                    return new HelpCommand();
                case "add":
                    string number = inputs.Length > 1 ? inputs[1] : null;
                    if (int.TryParse(number, out int n))
                    {
                        return new AddCommand(n);
                    }
                    else
                    {
                        return new UnknownCommand();
                    }

                default:
                    return new UnknownCommand();
            }
        }
    }
}
