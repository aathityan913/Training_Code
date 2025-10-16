using System;

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
            try
            {
                Console.WriteLine("===== Meeting Day Checker =====");
                Console.Write("Enter the meeting day (e.g., Monday): ");
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Error: Day name cannot be empty.");
                    return;
                }

                try
                {
                    // Try converting user input to Enum (case-insensitive)
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
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Invalid input format: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while checking the day: {ex.Message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected program error: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        // Function to check if it’s a weekday
        static bool IsWeekday(Weekdays day)
        {
            return day != Weekdays.Saturday && day != Weekdays.Sunday;
        }
    }
}
