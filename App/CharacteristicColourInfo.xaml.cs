using Rootmap.Configurator.ViewModels;

namespace Rootmap.Configurator
{
  public partial class CharacteristicColourInfo : BaseCodeBehind, IRemovable
  {
    private readonly Schema.Renderer.CharacteristicColourInfo _dataModel;

    public CharacteristicColourInfo() : this(new Schema.Windows.CharacteristicColourInfo(), null)
    { }

    public CharacteristicColourInfo(Schema.Renderer.CharacteristicColourInfo dataModel, BaseViewModel viewModel = null)
    {
      _dataModel = dataModel;
      ViewModel = viewModel ?? new RendererCharacteristicColourInfoViewModel(dataModel);
      Init();
      InitializeComponent();
    }

    public CharacteristicColourInfo(Schema.Windows.CharacteristicColourInfo dataModel, BaseViewModel viewModel = null)
    {
      _dataModel = new Schema.Renderer.CharacteristicColourInfo
      {
        characteristic_max = dataModel.characteristic_max,
        characteristic_min = dataModel.characteristic_min,
        characteristic_name = dataModel.characteristic_name,
        colour_max = dataModel.colour_max,
        colour_min = dataModel.colour_min,
        process_name = dataModel.process_name
      };
      ViewModel = viewModel ?? new WindowCharacteristicColourInfoViewModel(dataModel);
      Init();
      InitializeComponent();
    }

    public event DeletedEventHandler Deleted = delegate { };
    private void Delete(object sender, System.Windows.RoutedEventArgs e) => Deleted(_dataModel);
  }
}
