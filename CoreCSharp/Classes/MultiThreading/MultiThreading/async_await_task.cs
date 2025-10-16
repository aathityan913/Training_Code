using System.Threading.Tasks;

public class AsyncAwaitExample
{
    private Printer _printer;

    public AsyncAwaitExample(Printer printer)
    {
        _printer = printer;
    }

    public async Task StartPrinting()
    {
        Task t1 = Task.Run(() => _printer.PrintMessage("Async Task 1"));
        Task t2 = Task.Run(() => _printer.PrintMessage("Async Task 2"));
        await Task.WhenAll(t1, t2);
    }
}
