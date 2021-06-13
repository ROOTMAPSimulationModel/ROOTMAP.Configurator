using System;
using System.Linq;

namespace Rootmap.Configurator.ViewModels
{
  public class RainfallEvent
  {
    public decimal Radiation { get; set; }
    public decimal MaxTemp { get; set; }
    public decimal MinTemp { get; set; }
    public decimal RainAmountInCm { get; set; }
    public decimal PanEvaporation { get; set; }
    public decimal TimeInDays { get; set; }

    public static RainfallEvent Parse(string dataModel)
    {
      var chunks = (dataModel ?? throw new ArgumentNullException(nameof(dataModel)))
          .Split(',')
          .Where(x => !string.IsNullOrWhiteSpace(x))
          .Select(x => x.Trim())
          .ToArray();
      if (chunks.Length != 6)
      {
        throw new ArgumentException("Rainfall event must be a comma-separated string of six decimal numbers.", nameof(dataModel));
      }
      var re = new RainfallEvent
      {
        Radiation = decimal.Parse(chunks[0]),
        MaxTemp = decimal.Parse(chunks[1]),
        MinTemp = decimal.Parse(chunks[2]),
        RainAmountInCm = decimal.Parse(chunks[3]),
        PanEvaporation = decimal.Parse(chunks[4]),
        TimeInDays = decimal.Parse(chunks[5]),
      };
      return re;
    }
  }

  public class RainfallEventViewModel : BaseViewModel
  {
    private readonly RainfallEvent _dataModel;
    private bool _markedForDeletion;

    public RainfallEventViewModel(string dataModel)
    {
      _dataModel = RainfallEvent.Parse(dataModel);
      RaiseAllPropertiesChanged();
    }

    public decimal Radiation
    {
      get => _dataModel.Radiation;
      set
      {
        _dataModel.Radiation = value;
        RaisePropertyChanged();
      }
    }

    public decimal MaxTemp
    {
      get => _dataModel.MaxTemp;
      set
      {
        _dataModel.MaxTemp = value;
        RaisePropertyChanged();
      }
    }

    public decimal MinTemp
    {
      get => _dataModel.MinTemp;
      set
      {
        _dataModel.MinTemp = value;
        RaisePropertyChanged();
      }
    }

    public decimal RainAmountInCm
    {
      get => _dataModel.RainAmountInCm;
      set
      {
        _dataModel.RainAmountInCm = value;
        RaisePropertyChanged();
      }
    }

    public decimal PanEvaporation
    {
      get => _dataModel.PanEvaporation;
      set
      {
        _dataModel.PanEvaporation = value;
        RaisePropertyChanged();
      }
    }

    public decimal TimeInDays
    {
      get => _dataModel.TimeInDays;
      set
      {
        _dataModel.TimeInDays = value;
        RaisePropertyChanged();
      }
    }

    public bool MarkedForDeletion
    {
      get => _markedForDeletion;
      set => _markedForDeletion = value;
    }

    public override string ToString() => $"{Radiation},{MaxTemp},{MinTemp},{RainAmountInCm},{PanEvaporation},{TimeInDays}";
  }
}
