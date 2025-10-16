using System;
using System.Collections.Generic;
namespace csharp.training.congruent.apps
{
    internal class Account : IAccount
    {
        private double balance;
        private readonly List<IObserver> observers = new List<IObserver>();

        public double Balance
        {
            get => balance;
            private set => balance = value; // Only this class can change balance
        }

        public void Attach(IObserver observer)
        {
            observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in observers)
            {
                observer.Listen(this);
            }
        }

        public void DepositMoney(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Deposit amount must be positive.");
                return;
            }

            Balance += amount;
            Console.WriteLine($"Deposited: {amount}");
            Notify();
        }

        public void WithDrawMoney(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Withdraw amount must be positive.");
                return;
            }

            if (amount > Balance)
            {
                Console.WriteLine("Insufficient balance!");
                return;
            }

            Balance -= amount;
            Console.WriteLine($"Withdrawn: {amount}");
            Notify();
        }
    }
}
