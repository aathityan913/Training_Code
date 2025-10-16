namespace csharp.training.congruent.classes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int result = 0;

            Console.WriteLine("Enter integers to add to the total. Enter 0 to stop.");

            // Using a for loop with an infinite condition
            for (; ; )
            {
                Console.Write("Enter a number: ");
                string input = Console.ReadLine();

                try
                {
                    int number = int.Parse(input);

                    if (number == 0)
                    {
                        break; // Stop the loop if user enters 0
                    }

                    result += number; // Add the number
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input! Please enter a valid integer.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Number too large! Please enter a smaller integer.");
                }
            }

            Console.WriteLine($"\nThe final sum of all numbers entered is: {result}");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
