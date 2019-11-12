using System;
using System.Collections.Generic;
using System.Text;

namespace ChainOfResponsibility
{

    interface ITransactionCommand
    {
        void Execute();
    }
    class Transaction : ITransactionCommand
    {

        private readonly long balance;

        public Transaction(BankAccount account)
        {
            this.balance = account.Balance;
        }
        public void Execute()
        {
            Console.WriteLine("Sell initiated");
        }
    }
}
