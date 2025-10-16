using System;

namespace csharp.training.congruent.apps
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Account myAccount = new Account();

            SMSObserver smsObserver = new SMSObserver("+91-9876543210");
            EmailObserver emailObserver = new EmailObserver("user@example.com");

            myAccount.Attach(smsObserver);
            myAccount.Attach(emailObserver);

            Console.WriteLine("Depositing 500...");
            myAccount.DepositMoney(500);

            Console.WriteLine("Withdrawing 200...");
            myAccount.WithDrawMoney(200);

            Console.WriteLine($"Final Balance: {myAccount.Balance}");
        }
    }
}
