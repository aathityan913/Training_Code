using System;

public class Program
{
    public static async System.Threading.Tasks.Task Main()
    {
        Printer printer = new Printer();

        new ThreadExample(printer).StartPrinting();
        new ThreadPoolExample(printer).StartPrinting();
        new TaskExample(printer).StartPrinting();
        new ParallelExample(printer).StartPrinting();
        await new AsyncAwaitExample(printer).StartPrinting();

        Console.WriteLine("All threading examples completed.");
    }
}
