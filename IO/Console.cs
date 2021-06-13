namespace Rootmap.IO
{
  public class Console : IInput, IOutput
  {
    public void Clear() => System.Console.Clear();

    public string ReadLine() => System.Console.ReadLine();

    public void WriteLine() => System.Console.WriteLine();

    public void WriteLine(string line) => System.Console.WriteLine(line);
  }
}
