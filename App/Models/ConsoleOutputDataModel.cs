using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Rootmap.IO;

namespace Rootmap.Configurator
{
  public class ConsoleOutputDataModel : IOutput, INotifyPropertyChanged
  {
    private readonly List<string> _lines = new List<string>();

    public event PropertyChangedEventHandler PropertyChanged = delegate { };

    public void Clear()
    {
      _lines.Clear();
      PropertyChanged(this, new PropertyChangedEventArgs(nameof(Lines)));
    }

    public void WriteLine()
    {
      _lines.Add(System.Environment.NewLine);
      PropertyChanged(this, new PropertyChangedEventArgs(nameof(Lines)));
    }

    public void WriteLine(string line)
    {
      _lines.Add(line);
      PropertyChanged(this, new PropertyChangedEventArgs(nameof(Lines)));
    }

    public IList<string> Lines => _lines.AsReadOnly().ToList();
  }
}
