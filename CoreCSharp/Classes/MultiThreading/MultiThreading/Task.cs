using System.Threading.Tasks;

public class TaskExample
{
    private Printer _printer;

    public TaskExample(Printer printer)
    {
        _printer = printer;
    }

    public void StartPrinting()
    {
        Task t1 = Task.Run(() => _printer.PrintMessage("Task 1 Running"));
        Task t2 = Task.Run(() => _printer.PrintMessage("Task 2 Running"));
        Task.WaitAll(t1, t2);
    }
}
