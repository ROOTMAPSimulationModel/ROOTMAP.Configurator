using Rootmap.Configurator.ViewModels;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows;
using System;

namespace Rootmap.Configurator
{
  public abstract class BaseCodeBehind : UserControl, INotifyPropertyChanged
  {
    protected void Init()
    {
      if (ViewModel == null)
      {
        throw new ArgumentNullException("ViewModel must be initialised in derived class constructor before Init() is called!");
      }
      DataContext = ViewModel;
      ViewModel.PropertyChanged += _viewModel_PropertyChanged;
    }

    public BaseViewModel ViewModel { get; protected set; }

    public event PropertyChangedEventHandler PropertyChanged = delegate { };
    protected void _viewModel_PropertyChanged(object sender, PropertyChangedEventArgs e) => PropertyChanged(sender, e);

    /// <summary>
    /// Derived classes should override this method if they need to do custom OnPropertyChanged stuff.
    /// </summary>
    protected virtual void OnPropertyChanged() { }
    protected void HandleChange(object sender, SelectionChangedEventArgs args) => FocusIfProgrammaticallyChanging(sender);
    protected void HandleChange(object sender, TextChangedEventArgs args) => FocusIfProgrammaticallyChanging(sender);
    protected void HandleChange(object sender, RoutedEventArgs args) => FocusIfProgrammaticallyChanging(sender);

    private void FocusIfProgrammaticallyChanging(object sender)
    {
      if (ViewModel.UndoingOrRedoing)
      {
        ((UIElement)sender)?.Focus();
      }
    }
  }
}
