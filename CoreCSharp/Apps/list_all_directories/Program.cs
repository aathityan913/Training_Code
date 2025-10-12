
namespace csharp.training.congruent.apps
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the directory path: ");
            string dirPath = Console.ReadLine();

            if (Directory.Exists(dirPath))
            {
                Console.WriteLine("\nFiles in directory:\n");

                string[] files = Directory.GetFiles(dirPath);

                foreach (string file in files)
                {
                    FileInfo fileInfo = new FileInfo(file);
                    Console.WriteLine($"{fileInfo.Name,-40} {fileInfo.Length} bytes");
                    //Print the filename left-aligned in a field of 40 characters, to make columns neat.
                }
            }
            else
            {
                Console.WriteLine("The specified directory does not exist.");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
