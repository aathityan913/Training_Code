public class ThreadExample
{
    private Printer _printer;

    public ThreadExample(Printer printer)
    {
        _printer = printer;
    }

    public void StartPrinting()
    {
        Thread t1 = new Thread(() => _printer.PrintMessage("Printing from Thread 1"));
        Thread t2 = new Thread(() => _printer.PrintMessage("Printing from Thread 2"));

        t1.Name = "T1";
        t2.Name = "T2";

        t1.Start();
        t2.Start();
        t1.Join();
        t2.Join();
    }
}
