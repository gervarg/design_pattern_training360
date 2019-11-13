using System;
using System.Collections.ObjectModel;

namespace Mediator
{
    class Program
    {
        // Summary:
        // * Mediator pattern adds a third party object (called mediator) 
        // to control the interaction between two objects (called colleagues). 
        // It helps reduce the coupling between the classes communicating with each other. 
        // Because now they don't need to have the knowledge of each other's implementation.
        //
        // * A közvetítő feladata, hogy vezérelje és összehangolja objektumok egy csoportjának
        // együttműködését.  A közvetítő olyan köztes rétegként szolgál, amely megakadályozza, 
        // hogy a csoport objektumai közvetlenül hivatkozzanak egymásra. (~ laza csatolás)
        // A köztük lévő kapcsolatok egymástól függetlenül módosíthatók.
        static void Main(string[] args)
        {
            //ChatExample();
            //HubExample();
            //UiExample();
            //MvvmExample();
            WesternUnionExample();
            WesternExample();
        }

        private static void WesternExample()
        {
            Western westernUnion = new Western();
            ClientAccount client1 = new ClientAccount("Pista") { Cash = 200_000 };
            ClientAccount client2 = new ClientAccount("Erzsi") { Cash = 0 };

            Console.WriteLine(westernUnion);
            Console.WriteLine(client1);
            Console.WriteLine(client2);
            client1.Deposit(westernUnion, 150_000);

            Console.WriteLine(westernUnion);
            Console.WriteLine(client1);
            Console.WriteLine(client2);
            client1.Transfer(westernUnion, 100_000, client2);

            Console.WriteLine(westernUnion);
            Console.WriteLine(client1);
            Console.WriteLine(client2);
            client2.Withraw(westernUnion, 80_000);
        }

        private static void WesternUnionExample()
        {
            ITransferMediator mediator = new WesternUnionExample();
            var client1 = new BankClient("Gergő", 100_000_0, mediator);
            var client2 = new BankClient("Ági", 200_000, mediator);
            Console.WriteLine(client2.Balance);
            client1.SendMoney(100_000, client2);
            Console.WriteLine(client2.Balance);
        }

        private static void MvvmExample()
        {
            DropDownList dropDownList = new DropDownList();
            ObservableCollection<string> model = new ObservableCollection<string>();
            MvvmMediator mvvmMediator = new MvvmMediator(dropDownList, model);

            Console.WriteLine(string.Join(',', dropDownList.Items));
            model.Add("Első");
            Console.WriteLine(string.Join(',', dropDownList.Items));
            model.Add("Második");
            Console.WriteLine(string.Join(',', dropDownList.Items));
            model.Add("Harmadik");
            Console.WriteLine(string.Join(',', dropDownList.Items));
            model.Remove("Második");
            Console.WriteLine(string.Join(',', dropDownList.Items));
        }

        private static void UiExample()
        {
            TextBox textBox = new TextBox();
            CheckBox checkBox = new CheckBox();
            DropDownList dropDownList = new DropDownList();

            UiMediator uiMediator = new UiMediator(dropDownList, textBox, checkBox);

            // 1.
            checkBox.IsChecked = true;            
            Console.WriteLine(textBox.Text);
            Console.WriteLine(string.Join(',', dropDownList.Items));

            // 2.
            checkBox.IsChecked = false;
            Console.WriteLine(textBox.Text);
            Console.WriteLine(string.Join(',', dropDownList.Items));
        }

        private static void HubExample()
        {
            IHub hub = new Hub();
            var client1 = new Client("Client-1", hub);
            hub.Clients.Add(client1);
            hub.Clients.Add(new Client("Client-2", hub));
            hub.Clients.Add(new Client("Client-3", hub));
            hub.Clients.Add(new Client("Client-4", hub));
            hub.Clients.Add(new Client("Client-5", hub));
            client1.Broadcast("Hello! Can you hear me?");
        }

        private static void ChatExample()
        {
            IChatRoomMediator mediator = new ChatRoom();

            User John = new User("John Doe", mediator);
            User Jane = new User("Jane Doe", mediator);

            John.Send("Hi there!");
            Jane.Send("Hey!");
        }
    }
}
