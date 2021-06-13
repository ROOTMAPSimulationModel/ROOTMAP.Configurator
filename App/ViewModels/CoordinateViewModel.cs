using System;
using System.Linq;

namespace Rootmap.Configurator.ViewModels
{
  public class CoordinateViewModel : BaseViewModel
  {
    private double _x;
    public double X
    {
      get => _x;
      set
      {
        _x = value;
        RaisePropertyChanged();
      }
    }

    private double _y;
    public double Y
    {
      get => _y;
      set
      {
        _y = value;
        RaisePropertyChanged();
      }
    }

    private double _z;
    public double Z
    {
      get => _z;
      set
      {
        _z = value;
        RaisePropertyChanged();
      }
    }

    public CoordinateViewModel(double x, double y, double z)
    {
      _x = x;
      _y = y;
      _z = z;
    }

    public CoordinateViewModel(string coordinateString)
    {
      if (!string.IsNullOrWhiteSpace(coordinateString))
      {
        var parsedChunks = coordinateString
            .Trim(' ', ',')
            .Split(',')
            .Select(x => double.Parse(x));
        if (parsedChunks.Count() != 3)
        {
          throw new ArgumentException("3D coordinate string must be three comma-separated numbers", nameof(coordinateString));
        }
        _x = parsedChunks.ElementAt(0);
        _y = parsedChunks.ElementAt(1);
        _z = parsedChunks.ElementAt(2);
      }
    }

    public override string ToString() => $"{X},{Y},{Z}";
  }
}
