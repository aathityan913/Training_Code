using System;
using System.Threading;

public class Printer
{
    public void PrintMessage(string message)
    {
        lock (this)
        {
            Console.WriteLine($"{Thread.CurrentThread.Name}: {message}");
            Thread.Sleep(500); // Simulate work
        }
    }
}
