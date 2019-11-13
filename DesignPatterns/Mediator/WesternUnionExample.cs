namespace Mediator
{
    class WesternUnionExample : ITransferMediator
    {
        public void Transfer(double money, BankClient client)
        {
            client.Balance += (money * 0.095);                        
        }
    }

    interface ITransferMediator
    {
        void Transfer(double money, BankClient client);
    }

    class BankClient
    {
        public string Name { get; }

        public double Balance { get; set; }

        public ITransferMediator Mediator { get; }

        public BankClient(string name, double balance, ITransferMediator mediator)
        {
            Name = name;
            Balance = balance;
            Mediator = mediator;
        }

        public void SendMoney(double money, BankClient client)
        {
            this.Balance -= money;
            this.Mediator.Transfer(money, client);
        }
    }
}
