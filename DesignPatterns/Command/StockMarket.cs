using System;
using System.Collections.Generic;

namespace Command
{
    // The receiver
    class Stock
    {
        public Stock(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }

        public string Name { get; }
        public int Quantity { get; }


        public void Buy()
        {
            Console.WriteLine($"Stock [Name: {Name}, Quantity: {Quantity}] bought.");
        }

        public void Sell()
        {
            Console.WriteLine($"Stock [Name: {Name}, Quantity: {Quantity}] sold.");
        }
    }

    // The command interface
    interface IOrder
    {
        void Execute();
    }

    // Concrete command
    class BuyStock : IOrder
    {
        private readonly Stock stock;

        public BuyStock(Stock stock)
        {
            this.stock = stock;
        }

        public void Execute()
        {
            stock.Buy();
        }
    }

    // Concrete command
    class SellStock : IOrder
    {
        private readonly Stock stock;

        public SellStock(Stock stock)
        {
            this.stock = stock;
        }

        public void Execute()
        {
            stock.Sell();
        }
    }

    // The command invoker class
    class Broker
    {
        private readonly List<IOrder> orders = new List<IOrder>();

        public void TakeOrder(IOrder order)
        {
            orders.Add(order);
        }

        public void PlaceOrders()
        {

            foreach (IOrder order in orders)
            {
                order.Execute();
            }
            orders.Clear();
        }
    }
}
