namespace CQUELLETestApp;

public class ConsoleProvider : IOSystemProvider
{
    public string ReadLine() => Console.ReadLine() ?? "";
    public void WriteLine(object value) => Console.WriteLine(value);
}