using System.Threading;

public class ThreadPoolExample
{
    private Printer _printer;

    public ThreadPoolExample(Printer printer)
    {
        _printer = printer;
    }

    public void StartPrinting()
    {
        ThreadPool.QueueUserWorkItem(state => _printer.PrintMessage("ThreadPool Worker 1"));
        ThreadPool.QueueUserWorkItem(state => _printer.PrintMessage("ThreadPool Worker 2"));
        Thread.Sleep(1000); // Allow threads to finish
    }
}
