using System;

namespace ChainOfResponsibility
{
    public class Customer
    {
        public string Name { get; }
        
        public long Balance { get; }
       

        public Customer(string name, long balance)
        {
            Name = name;
            Balance = balance;            
        }

        internal bool CanBuy(long housePrice)
        {
            return housePrice <= Balance;
        }
    }
}