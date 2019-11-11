using System;
using System.Collections.Generic;

namespace Mediator
{
    interface IHub
    {
        List<Client> Clients { get; }
        void Broadcast(Client sender, string message);
    }

    class Hub : IHub
    {
        public List<Client> Clients { get; } = new List<Client>();

        public void Broadcast(Client sender, string message)
        {
            Console.WriteLine($"{sender.Name} broadcasting message!");
            foreach (var client in Clients)
            {
                if (client != sender)
                {
                    client.ReceiveMessage(message);
                }
            }
        }
    }

    class Client
    {
        private readonly IHub hub;

        public Client(string name, IHub hub)
        {
            Name = name;
            this.hub = hub;
        }

        public string Name { get; }

        public void Broadcast(string message)
        {
            hub.Broadcast(this, message);
        }

        public void ReceiveMessage(string message)
        {
            Console.WriteLine($"{Name} got the message: {message}");
        }
    }
}
