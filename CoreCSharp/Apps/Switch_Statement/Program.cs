
namespace csharp.training.congruent.apps
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Congruent Festival Finder!");

            while (true)
            {
                Console.Write("Enter the month number (1-12) or 0 to exit: ");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out int month))
                {
                    Console.WriteLine("Invalid input! Please enter a number between 1 and 12.");
                    continue;
                }

                if (month == 0)
                {
                    Console.WriteLine("Exiting program. Goodbye!");
                    break;
                }

                switch (month)
                {
                    case 1:
                        Console.WriteLine("Festivals: New Year, Pongal");
                        break;
                    case 2:
                        Console.WriteLine("Festivals: Valentine's Day");
                        break;
                    case 3:
                        Console.WriteLine("Festivals: Holi");
                        break;
                    case 4:
                        Console.WriteLine("Festivals: Good Friday, Easter");
                        break;
                    case 5:
                        Console.WriteLine("Festivals: Labor Day");
                        break;
                    case 6:
                        Console.WriteLine("Festivals: World Environment Day");
                        break;
                    case 7:
                        Console.WriteLine("Festivals: Guru Purnima");
                        break;
                    case 8:
                        Console.WriteLine("Festivals: Raksha Bandhan, Independence Day");
                        break;
                    case 9:
                        Console.WriteLine("Festivals: Ganesh Chaturthi");
                        break;
                    case 10:
                        Console.WriteLine("Festivals: Gandhi Jayanti, Dussehra");
                        break;
                    case 11:
                        Console.WriteLine("Festivals: Diwali, Thanksgiving");
                        break;
                    case 12:
                        Console.WriteLine("Festivals: Christmas, New Year's Eve");
                        break;
                    default:
                        Console.WriteLine("Invalid month! Please enter a number between 1 and 12.");
                        break;
                }

                Console.WriteLine(); // blank line for readability
            }
        }
    }
}
