using System;
using System.IO;

namespace csharp.training.congruent.apps
{
    class FileDirectoryCreator
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== File and Directory Creator ===");

            try
            {
                Console.Write("Enter full path (file or directory): ");
                string path = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(path))
                    throw new ArgumentNullException(nameof(path), "Path cannot be empty or null.");

                Console.Write("Do you want to create a file or directory? (f/d): ");
                string choice = Console.ReadLine()?.Trim().ToLower();

                if (choice == "f")
                {
                    CreateFileWithDirectories(path);
                }
                else if (choice == "d")
                {
                    CreateDirectoryRecursively(path);
                }
                else
                {
                    Console.WriteLine("Invalid choice! Please enter 'f' or 'd'.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n--- ERROR DETAILS ---");
                Console.WriteLine($"Message: {ex.Message}");
                Console.WriteLine($"Source: {ex.Source}");
                Console.WriteLine($"Method: {ex.TargetSite}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                Console.WriteLine("---------------------");
            }

            Console.WriteLine("\nProgram completed.");
        }

        static void CreateDirectoryRecursively(string path)
        {
            try
            {
                if (Directory.Exists(path))
                {
                    Console.WriteLine("Directory already exists!");
                    return;
                }

                Directory.CreateDirectory(path);
                Console.WriteLine($"Directory created successfully: {path}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError creating directory: {ex.Message}");
                Console.WriteLine($"Occurred at: {ex.TargetSite}");
                throw;
            }
        }

        static void CreateFileWithDirectories(string filePath)
        {
            try
            {
                string? directory = Path.GetDirectoryName(filePath);

                if (string.IsNullOrEmpty(directory))
                    throw new ArgumentException("Invalid file path. Directory portion not found.");

                if (!Directory.Exists(directory))
                {
                    Console.WriteLine("Creating required directories...");
                    Directory.CreateDirectory(directory);
                }

                if (!File.Exists(filePath))
                {
                    using (File.Create(filePath))
                    {
                    }
                    Console.WriteLine($"File created successfully: {filePath}");
                }
                else
                {
                    Console.WriteLine("File already exists!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError creating file: {ex.Message}");
                Console.WriteLine($"Occurred at: {ex.TargetSite}");
                throw;
            }
        }
    }
}
