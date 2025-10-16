using System;
using System.Collections.Generic;

namespace csharp.training.congruent.apps
{
    // Observer interface
    public interface IObserver
    {
        void UpdateDeposit(decimal depositAmount, decimal currentBalance);
        void UpdateWithdrawal(decimal withdrawnAmount, decimal currentBalance);
        void UpdateAccountClosed();
    }

    // Subject interface
    public interface ISubject
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void NotifyDeposit(decimal depositAmount);
        void NotifyWithdrawal(decimal withdrawnAmount);
        void NotifyAccountClosed();
    }

    // Account interface
    public interface IAccount : ISubject
    {
        decimal Balance { get; }
        bool IsClosed { get; }
        void Deposit(decimal amount);
        void Withdraw(decimal amount);
        void CloseAccount();
    }

    // Concrete Account implementing IAccount
    public class Account : IAccount
    {
        private readonly List<IObserver> observers;
        private decimal balance;
        private bool isClosed = false;

        public Account(IEnumerable<IObserver> initialObservers)
        {
            observers = new List<IObserver>(initialObservers);
        }

        public decimal Balance => balance;
        public bool IsClosed => isClosed;

        public void Attach(IObserver observer)
        {
            observers.Add(observer);
            Console.WriteLine("[Account] Notifier attached.");
        }

        public void Detach(IObserver observer)
        {
            if (observers.Remove(observer))
            {
                Console.WriteLine("[Account] Notifier detached.");
            }
        }

        public void NotifyDeposit(decimal depositAmount)
        {
            foreach (var obs in observers)
                obs.UpdateDeposit(depositAmount, balance);
        }

        public void NotifyWithdrawal(decimal withdrawnAmount)
        {
            foreach (var obs in observers)
                obs.UpdateWithdrawal(withdrawnAmount, balance);
        }

        public void NotifyAccountClosed()
        {
            foreach (var obs in observers)
                obs.UpdateAccountClosed();
        }

        public void Deposit(decimal amount)
        {
            if (isClosed)
            {
                Console.WriteLine("[Account] Cannot deposit. Account is closed.");
                return;
            }

            if (amount <= 0)
            {
                Console.WriteLine("[Account] Deposit amount must be positive.");
                return;
            }

            balance += amount;
            Console.WriteLine($"[Account] Deposited: ₹{amount}. Current balance: ₹{balance}");
            NotifyDeposit(amount);
        }

        public void Withdraw(decimal amount)
        {
            if (isClosed)
            {
                Console.WriteLine("[Account] Cannot withdraw. Account is closed.");
                return;
            }

            if (amount <= 0)
            {
                Console.WriteLine("[Account] Withdraw amount must be positive.");
                return;
            }

            if (amount > balance)
            {
                Console.WriteLine("[Account] Insufficient balance!");
                return;
            }

            balance -= amount;
            Console.WriteLine($"[Account] Withdrawn: ₹{amount}. Current balance: ₹{balance}");
            NotifyWithdrawal(amount);
        }

        public void CloseAccount()
        {
            if (isClosed)
            {
                Console.WriteLine("[Account] Account is already closed.");
                return;
            }

            isClosed = true;
            Console.WriteLine("[Account] Account is now closed.");
            NotifyAccountClosed();
        }
    }

    // Email notifier implementing IObserver
    public class EmailNotifier : IObserver
    {
        public void UpdateDeposit(decimal depositAmount, decimal currentBalance)
        {
            Console.WriteLine($"[Email] Deposit Alert: ₹{depositAmount}. New balance: ₹{currentBalance}");
        }

        public void UpdateWithdrawal(decimal withdrawnAmount, decimal currentBalance)
        {
            Console.WriteLine($"[Email] Withdrawal Alert: ₹{withdrawnAmount}. New balance: ₹{currentBalance}");
        }

        public void UpdateAccountClosed()
        {
            Console.WriteLine("[Email] Alert: The account has been closed.");
        }
    }

    // SMS notifier implementing IObserver
    public class SmsNotifier : IObserver
    {
        public void UpdateDeposit(decimal depositAmount, decimal currentBalance)
        {
            Console.WriteLine($"[SMS] Deposit Alert: ₹{depositAmount}. New balance: ₹{currentBalance}");
        }

        public void UpdateWithdrawal(decimal withdrawnAmount, decimal currentBalance)
        {
            Console.WriteLine($"[SMS] Withdrawal Alert: ₹{withdrawnAmount}. New balance: ₹{currentBalance}");
        }

        public void UpdateAccountClosed()
        {
            Console.WriteLine("[SMS] Alert: The account has been closed.");
        }
    }

    public class Program
    {
        public static void Main()
        {
            // Create observers
            var observers = new List<IObserver>
            {
                new EmailNotifier(),
                new SmsNotifier()
            };

            // Inject observers into account
            IAccount account = new Account(observers);

            // Perform some transactions automatically
            account.Deposit(5000);
            account.Withdraw(1500);
            account.Deposit(2000);
            account.Withdraw(1000);
            account.CloseAccount();
            account.Deposit(500);  // Should be blocked
            account.Withdraw(300); // Should be blocked
        }
    }
}
