namespace csharp.training.congruent.apps
{
    public class Account
    {
        public string AccountHolder { get; set; }
        public double Balance { get; set; }

        // Constructor
        public Account(string name, double balance)
        {
            AccountHolder = name;
            Balance = balance;
        }
    }
}
