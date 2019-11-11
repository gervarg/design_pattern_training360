using System;

namespace ChainOfResponsibility
{
    abstract class Account
    {
        protected float _balance;
        public Account Successor { get; set; }

        public Account(float balance)
        {
            _balance = balance;
        }

        public void Pay(float amountToPay)
        {
            // Check if current acount have enough money to pay.
            if (CanPay(amountToPay))
            {
                Console.WriteLine($"Paid {amountToPay} using {GetType().Name}!");
            }
            else if (Successor != null)
            {
                Console.WriteLine($"Cannot pay using {GetType().Name}. Proceeding ..");
                // If current account have a successor account try paying using successor.
                Successor.Pay(amountToPay);
            }
            else
            {
                throw new InvalidOperationException("None of the accounts have enough balance!");
            }
        }

        protected bool CanPay(float amountRequired) => _balance >= amountRequired;
    }

    class Bank : Account
    {
        public Bank(float balance) : base(balance)
        {
        }
    }

    class Paypal : Account
    {
        public Paypal(float balance) : base(balance)
        {
        }
    }

    class Bitcoin : Account
    {
        public Bitcoin(float balance) : base(balance)
        {
        }
    }
}
