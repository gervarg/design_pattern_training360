using System;
using System.Collections.Generic;
using System.Text;

namespace Mediator
{
    class Western
    {

        private readonly Dictionary<Guid, decimal> accounting = new Dictionary<Guid, decimal>();

        public Western()
        {
            accounting.Add(Guid.Empty, 0);
        }

        public void In(Guid clientId, decimal amount)
        {
            if(amount <= 0)
            {
                throw new ArgumentException();
            }

            if (!accounting.ContainsKey(clientId))
            {
                accounting.Add(clientId, 0);
            }

            accounting[clientId] += amount;
        }

        public decimal Out(Guid clientId, decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException();
            }

            if (!accounting.ContainsKey(clientId))
            {
                throw new ArgumentException();
            }
            if (amount <= accounting[clientId])
            {
                throw new ArgumentException();
            }

            accounting[clientId] -= amount;

            // WARNING: overflow check

            return amount;
        }

        public void Transfer(Guid senderId, Guid receiverId, decimal amount)
        {
            if (!accounting.ContainsKey(receiverId))
            {
                accounting.Add(receiverId, 0); //something something not right
            }
            if(amount > accounting[senderId])
            {
                throw new ArgumentException();
            }

            decimal fee = amount * 0.005M;

            accounting[receiverId] += (amount - fee);
            accounting[senderId] -= amount;
            accounting[Guid.Empty] += fee;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }

    class ClientAccount
    {
        public Guid Id { get; } = Guid.NewGuid();

        public string Name { get; set; }

        public decimal Cash { get; set; }

        public ClientAccount(string name)
        {
            Name = name;
        }

        public void Deposit(Western western, decimal amount)
        {
            if (amount >= Cash)
            {
                throw new ArgumentException();
            }
            Cash -= amount;
            western.In(Id, amount);
        }

        public void Withraw(Western western, decimal amount)
        {
            Cash += western.Out(Id, amount);
        }

        public void Transfer(Western western, decimal amount, ClientAccount client)
        {
            western.Transfer(Id, client.Id, amount);
        }

        public override string ToString()
        {
            return $"{Name} : Cash {Cash:C2}";
        }
    }
}
