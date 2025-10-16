using System;
using System.IO;

namespace csharp.training.congruent.apps
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"g:\sample123.txt";
            string content = "Hello, all hope you had a nice day";

            try
            {
                string directory = Path.GetDirectoryName(path);
                string root = Path.GetPathRoot(path);

                // Check if drive exists
                if (!Directory.Exists(root))
                {
                    Console.WriteLine($"Drive '{root}' not found.");
                    return;
                }

                // Check if directory exists, create if not
                if (!Directory.Exists(directory))
                {
                    Console.WriteLine("Directory does not exist. Attempting to create...");
                    Directory.CreateDirectory(directory);

                    if (!Directory.Exists(directory))
                    {
                        Console.WriteLine("Failed to create directory. Directory not found.");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Directory created successfully.");
                    }
                }

                // Write to file using StreamWriter
                using (StreamWriter writer = new StreamWriter(path))
                {
                    writer.WriteLine(content);
                }

                Console.WriteLine("File written successfully!");
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"Access denied: {ex.Message}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"IO error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }

            Console.WriteLine("Program finished.");
        }
    }
}
