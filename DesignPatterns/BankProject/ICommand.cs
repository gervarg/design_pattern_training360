using System;
using System.Collections.Generic;
using System.Text;

namespace BankProject
{
    interface ICommand
    {
        void Execute();

        void Revoke();

        bool Redo();
    }

    class TransferCommand : ICommand
    {

        // Vagy ő végzi vagy ő delegálja a feladatot egy másik osztálynak

        public DateTime? ExecutedAt { get; private set; }
        public Guid Source { get; }
        public Guid Target { get; }
        public decimal Amount { get; }
        public Dictionary<Guid, decimal> Accounts { get; }
        public int FeePercent { get; }

        public TransferCommand(Guid source, Guid target, decimal amount, Dictionary<Guid, decimal> accounts, int feePercent)
        {
            Source = source;
            Target = target;
            Amount = amount;
            Accounts = accounts;
            FeePercent = feePercent;
        }
        public void Execute()
        {
            if (!Accounts.ContainsKey(Source))
            {
                throw new ArgumentException($"{nameof(Source)} account could not be found! {Source}");
            }

            if (!Accounts.ContainsKey(Target))
            {
                throw new ArgumentException($"{nameof(Target)} account could not be found! {Target}");
            }

            if (Accounts[Source] < Amount)
            {
                throw new InvalidOperationException($"{nameof(Source)} Source account does not have enougy money!");
            }

            // Check overflow scenario
            decimal fee = Amount * FeePercent / 100;
            Accounts[Source] -= Amount;
            Accounts[Target] += Amount;
            Accounts[Guid.Empty] += fee;

            ExecutedAt = DateTime.UtcNow;            
        }

        public void Redo()
        {
            throw new NotImplementedException();
        }

        public void Revoke()
        {
            throw new NotImplementedException();
        }
    }
}
