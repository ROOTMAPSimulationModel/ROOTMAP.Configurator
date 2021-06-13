namespace Rootmap.IO
{
    public interface IOutput
    {
        void WriteLine();
        void WriteLine(string line);
        void Clear();
    }
}
