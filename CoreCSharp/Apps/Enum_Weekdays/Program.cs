namespace csharp.training.congruent.apps
{
    // Define an Enum for days of the week
    enum Weekdays
    {
        Sunday,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===== Meeting Day Checker =====");
            Console.Write("Enter the meeting day (e.g., Monday): ");
            string input = Console.ReadLine();

            // Try converting user input to Enum
            if (Enum.TryParse(input, true, out Weekdays meetingDay))
            {
                if (IsWeekday(meetingDay))
                {
                    Console.WriteLine($"{meetingDay} is a Weekday. ✅ Meeting can be scheduled.");
                }
                else
                {
                    Console.WriteLine($"{meetingDay} is a Weekend. ❌ Meeting not scheduled.");
                }
            }
            else
            {
                Console.WriteLine("Invalid day entered. Please enter a valid weekday name.");
            }
        }

        // Function to check if it’s a weekday
        static bool IsWeekday(Weekdays day)
        {
            return day != Weekdays.Saturday && day != Weekdays.Sunday;
        }
    }
}
