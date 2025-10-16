
namespace csharp.training.congruent.apps
{
    class Program
    {
        // Pass by value
        static void UpdateBalanceByValue(Account acc)
        {
            acc.Balance += 100; 
            acc = new Account("New Account", 500); 
        }

        // Pass by reference
        static void UpdateAccountByRef(ref Account acc)
        {
            acc.Balance += 200; 
            acc = new Account("Ref Account", 1000); 
        }

        static void Main(string[] args)
        {
            Account myAccount = new Account("Alice", 1000);

            Console.WriteLine($"Original Account: {myAccount.AccountHolder}, Balance: {myAccount.Balance}");

            UpdateBalanceByValue(myAccount);
            Console.WriteLine($"After UpdateBalanceByValue: {myAccount.AccountHolder}, Balance: {myAccount.Balance}");

            UpdateAccountByRef(ref myAccount);
            Console.WriteLine($"After UpdateAccountByRef: {myAccount.AccountHolder}, Balance: {myAccount.Balance}");
        }
    }
}
