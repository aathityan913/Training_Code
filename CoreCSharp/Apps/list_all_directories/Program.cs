

namespace csharp.training.congruent.apps
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter the directory path: ");
                string dirPath = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(dirPath))
                {
                    Console.WriteLine("Error: Directory path cannot be empty.");
                }
                else if (Directory.Exists(dirPath))
                {
                    Console.WriteLine("\nFiles in directory:\n");

                    try
                    {
                        string[] files = Directory.GetFiles(dirPath);

                        if (files.Length == 0)
                        {
                            Console.WriteLine("No files found in the directory.");
                        }
                        else
                        {
                            foreach (string file in files)
                            {
                                try
                                {
                                    FileInfo fileInfo = new FileInfo(file);
                                    Console.WriteLine($"{fileInfo.Name,-40} {fileInfo.Length} bytes");
                                    // Prints filename left-aligned in 40-character field
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"Error reading file info for '{file}': {ex.Message}");
                                }
                            }
                        }
                    }
                    catch (UnauthorizedAccessException)
                    {
                        Console.WriteLine("Error: You do not have permission to access this directory.");
                    }
                    catch (IOException ioEx)
                    {
                        Console.WriteLine($"I/O error occurred: {ioEx.Message}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Unexpected error reading files: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine("The specified directory does not exist.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
