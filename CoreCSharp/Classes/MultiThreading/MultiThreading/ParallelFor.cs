using System.Threading.Tasks;

public class ParallelExample
{
    private Printer _printer;

    public ParallelExample(Printer printer)
    {
        _printer = printer;
    }

    public void StartPrinting()
    {
        string[] messages = { "Parallel Task 1", "Parallel Task 2", "Parallel Task 3" };
        Parallel.For(0, messages.Length, i =>
        {
            _printer.PrintMessage(messages[i]);
        });
    }
}
