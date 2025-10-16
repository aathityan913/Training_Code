
namespace csharp.training.congruent.apps
{
    // Base class: all accounts can deposit
    public abstract class Account
    {
        public decimal Balance { get; protected set; }

        public virtual void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Deposit amount must be positive");

            Balance += amount;
            Console.WriteLine($"{GetType().Name}: Deposited {amount}, Balance = {Balance}");
        }
    }

    // Derived abstract class: accounts that can also withdraw
    public abstract class WithdrawableAccount : Account
    {
        public abstract void Withdraw(decimal amount);
    }

    // Concrete class: Current account (can deposit and withdraw)
    public class CurrentAccount : WithdrawableAccount
    {
        public override void Withdraw(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Withdraw amount must be positive");

            if (amount > Balance)
                throw new InvalidOperationException("Insufficient funds");

            Balance -= amount;
            Console.WriteLine($"{GetType().Name}: Withdrawn {amount}, Balance = {Balance}");
        }
    }

    // Concrete class: Savings account (can deposit and withdraw)
    public class SavingsAccount : WithdrawableAccount
    {
        public override void Withdraw(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Withdraw amount must be positive");

            if (amount > Balance)
                throw new InvalidOperationException("Insufficient funds");

            Balance -= amount;
            Console.WriteLine($"{GetType().Name}: Withdrawn {amount}, Balance = {Balance}");
        }
    }

    // Concrete class: Fixed-term deposit (only deposit, cannot withdraw)
    public class FixedTermDepositAccount : Account
    {
        // No Withdraw method – avoids violating LSP
    }

    // Banking service that works only with withdrawable accounts
    public class BankingAppWithdrawalService
    {
        public void WithdrawMoney(WithdrawableAccount account, decimal amount)
        {
            account.Withdraw(amount);
        }
    }

    class Program
    {
        static void Main()
        {
            var current = new CurrentAccount();
            var savings = new SavingsAccount();
            var fixedDeposit = new FixedTermDepositAccount();

            current.Deposit(1000);
            savings.Deposit(1500);
            fixedDeposit.Deposit(5000);

            var withdrawalService = new BankingAppWithdrawalService();
            withdrawalService.WithdrawMoney(current, 200);
            withdrawalService.WithdrawMoney(savings, 300);

            // withdrawalService.WithdrawMoney(fixedDeposit, 500); ❌ Not allowed (compile-time safety)
        }
    }
}
