using System;

namespace csharp.training.congruent.apps
{
    internal class SMSObserver : IObserver
    {
        private readonly string phoneNumber;

        public SMSObserver(string phoneNumber)
        {
            this.phoneNumber = phoneNumber;
        }

        public void Listen(IAccount account)
        {
            if (account is Account acc)
            {
                Console.WriteLine($"[SMS Sender] Balance: {acc.Balance} | SMS sent to {phoneNumber}");
            }
        }
    }
}
