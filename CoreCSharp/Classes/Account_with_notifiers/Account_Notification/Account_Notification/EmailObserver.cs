using System;

namespace csharp.training.congruent.apps
{
    internal class EmailObserver : IObserver
    {
        private readonly string emailAddress;

        public EmailObserver(string emailAddress)
        {
            this.emailAddress = emailAddress;
        }

        public void Listen(IAccount account)
        {
            if (account is Account acc)
            {
                Console.WriteLine($"[Email Sender] Balance: {acc.Balance} | Email sent to {emailAddress}");
            }
        }
    }
}
