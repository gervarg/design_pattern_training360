using System;

namespace Command
{
    // Summary:
    // * A lényeg, hogy folyamatokat zárunk egységbe.
    // * Allows you to encapsulate actions in objects. (Can be passed as parameter, like callback functions.)
    // * Command pattern can also be used to implement a transaction based system.
    // * Command pattern can also be used to implement menu system.
    // * Undo, Redo, Log, Transaction based systems (todo)
    // * EF Migration
    class Program
    {
        static void Main(string[] args)
        {
            //Example1();

           // Example2();

            //Example3();

            Example4();

            //Example5();
        }        

        private static void Example1()
        {
            ILoadDataCommand command1 = new LoadDataFromDatabaseCommand("ConnectionString");
            ILoadDataCommand command2 = new LoadDataFromWebserviceCommand("URL");
            ILoadDataCommand command3 = new LoadDataFromFileCommand("FileName");

            command1.Execute();
            command2.Execute();
            command3.Execute();

            ILoadDataCommand command4 = LoadDataCommandFactory.GetCommand("web", "url");
            command4.Execute();
        }

        private static void Example2()
        {
            string currentInput = null;
            ICommand lastCommand = null;
            CommandFactory commandFactory = new CommandFactory();

            while (currentInput != "close")
            {
                Console.Write("> ");
                currentInput = Console.ReadLine();
                string[] inputs = currentInput.Split(' ');
                if (inputs[0] == "undo")
                {
                    lastCommand?.Undo();
                }
                else
                {
                    lastCommand = commandFactory.GetCommand(inputs);
                    lastCommand.Execute();
                }
            }
        }

        private static void Example3()
        {
            User user = new User();

            // User presses calculator buttons
            user.Compute('+', 100);
            user.Compute('-', 50);
            user.Compute('*', 10);
            user.Compute('/', 2);

            // Undo 4 commands
            user.Undo(2);

            // Redo 3 commands
            user.Redo(3);
        }

        private static void Example4()
        {            
            BuyStock buyStockOrder = new BuyStock(new Stock("OTP", 1000));
            SellStock sellStockOrder = new SellStock(new Stock("Egis", 100));

            Broker broker = new Broker();
            broker.TakeOrder(buyStockOrder);
            broker.TakeOrder(sellStockOrder);

            broker.PlaceOrders();
        }

        private static void Example5()
        {
            // The client is our program
            var bulb = new Bulb();

            var turnOn = new TurnOn(bulb);
            var turnOff = new TurnOff(bulb);

            var remote = new RemoteControl();
            remote.Submit(turnOn);
            remote.Submit(turnOff);
        }
    }
}
