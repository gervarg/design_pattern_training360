using System;
using System.Collections.Generic;
using System.Text;

namespace BankProject
{
    interface IBank
    {
        Guid OpenAccount(string name, int age);

        void CloseAccount(Guid clientId);
    }

    class MyBank : IBank
    {

        private readonly Dictionary<Guid, decimal> accounts = new Dictionary<Guid, decimal>();
        private readonly ILoggerService loggerService;

        public MyBank(ILoggerService loggerService)
        {
            this.loggerService = loggerService;
            accounts.Add(Guid.Empty, 0);
        }

        public void CloseAccount(Guid clientId)
        {
            if (accounts.ContainsKey(clientId))
            {
                if (accounts[clientId] < 0)
                {
                    loggerService.Log($"You are in debt! Cannot close account! {clientId}");
                }
                loggerService.Log($"Give back the rest of the money: {accounts[clientId]}");
                accounts.Remove(clientId);
            }
            else
            {
                loggerService.Log($"There is no account with that id. {clientId}");
            }
           
        }

        public Guid OpenAccount(string name, int age)
        {
            var clientId = Guid.NewGuid();
            accounts.Add(clientId, 10_000);
            //if (!accounts.ContainsKey())
            //{

            //}
            //TODO save data to repo
            loggerService.Log($"New client has arrived: {clientId}");

            return clientId;
        }

        public void TakeTransferOrder(Guid source, Guid target, decimal amount)
        {
            //INVOKER FROM COMMAND PATTERN
        }
    }
}
