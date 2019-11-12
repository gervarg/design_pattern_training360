using System;

namespace ChainOfResponsibility
{
    public class Customer
    {
        public string Name { get; }
        
        private BankAccount BankAccount { get; }
       

        public Customer(string name, BankAccount bankAccount)
        {
            Name = name;
            BankAccount = bankAccount;            
        }

        internal bool CanBuy(long housePrice)
        {
            return housePrice <= BankAccount.Balance;
        }
    }

    public class BankAccount
    {
        public long Balance { get; set; }

        public BankAccount(long balance)
        {
            Balance = balance;
        }
    }
}