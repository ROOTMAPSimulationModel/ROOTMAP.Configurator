using Rootmap.Configurator.Services;
using Rootmap.Configurator.Schema;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Controls;

namespace Rootmap.Configurator
{
  /// <summary>
  /// Interaction logic for Detail.xaml
  /// </summary>
  public partial class Detail : UserControl, INotifyPropertyChanged
  {
    public Detail()
    {
      InitializeComponent();
    }

    private readonly IParent _dataModel;
    private readonly IPersister _persister;
    private readonly string _filename;
    private readonly string _owner;
    private readonly string _outputDirectory;

    public event PropertyChangedEventHandler PropertyChanged;

    public Detail(dynamic dataModel, string outputDirectory, string filename, string owner)
    {
      _outputDirectory = outputDirectory;
      _filename = filename;
      _owner = owner;
      _persister = SimpleIoC.Container.Resolve<IPersister>();
      _dataModel = dataModel ?? throw new ArgumentNullException(nameof(dataModel));
      DataContext = this;
      InitializeComponent();
      addNewButton.Visibility = _dataModel.CanAdd
          ? System.Windows.Visibility.Visible
          : System.Windows.Visibility.Hidden;
      InitialiseChildren();
    }

    private void InitialiseChildren(bool notifyChanged = false)
    {
      _dataModel.OverrideOwner(_owner);
      elementList.Children.Clear();
      var children = _dataModel.GetChildren();
      for (var i=0; i< children.Count;i++)
      {
        var ctrl = ChildControlFactory.Create(children[i], _filename, _owner, i);
        if (ctrl != null)
        {
          elementList.Children.Add(ctrl);
          var listenable = ctrl as INotifyPropertyChanged ?? throw new ApplicationException($"User control {ctrl} does not implement INotifyPropertyChanged.");
          listenable.PropertyChanged += Control_PropertyChanged;
          if (ctrl is IRemovable isRemovable)
          {
            isRemovable.Deleted += DeleteChild;
          }
        }
      }
      if (notifyChanged)
      {
        PropertyChanged(this, new PropertyChangedEventArgs(_filename));
      }
    }

    public void AddChild(int? index = null)
    {
      if (_dataModel.CanAdd)
      {
        _dataModel.CreateNewChild(index);
        InitialiseChildren(true);
      }
    }

    private void DeleteChild(object childToDelete)
    {
      if (_dataModel.CanRemove)
      {
        var idx = _dataModel
            .GetChildren()
            .IndexOf(childToDelete);

        _dataModel.RemoveChild(idx);

        InitialiseChildren(true);
      }
    }

    private void Control_PropertyChanged(object sender, PropertyChangedEventArgs e) => PropertyChanged(this, new PropertyChangedEventArgs(_filename));

    public string Filename => _filename;

    public string OwnerLabel => $"Owner: {_owner}";

    private void DeleteButton_Clicked(object sender, System.Windows.RoutedEventArgs e) => DeleteChild(_dataModel.GetChildren().Last());

    private void AddNewButton_Clicked(object sender, System.Windows.RoutedEventArgs e) => AddChild();
  }
}
