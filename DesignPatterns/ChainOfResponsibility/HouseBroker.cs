using System;
using System.Collections.Generic;

namespace ChainOfResponsibility
{
    internal class HouseBroker
    {
        public List<Customer> Customers = new List<Customer>();
        public HouseBroker()
        {
        }

        public void SellHouse(long housePrice)
        {
            foreach (var customer in Customers)
            {
                if (customer.CanBuy(housePrice))
                {
                    Console.WriteLine($"{customer.Name} bought the house.");
                    return;
                }
            }
            Console.WriteLine("None of the customers can buy this house!");
        }
        
    }

}