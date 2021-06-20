using Coherent.Project.Wpf.Template.Gui.ViewModels;
using ReactiveUI;
using System.Reactive.Disposables;
using System.Windows;

namespace Coherent.Project.Wpf.Template.Gui.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ReactiveWindow<MainViewModel>, IViewFor<MainViewModel>
    {
        public MainWindow(MainViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;

            this.WhenActivated(disposables => {

                this.OneWayBind(ViewModel, vm => vm.DeviceValue, view => view.DeviceValue.Text, value => $"{value:F3}")
                    .DisposeWith(disposables);

                this.OneWayBind(ViewModel, vm => vm.UpdateDeviceValue, view => view.DeviceNewValueButton.Command)
                    .DisposeWith(disposables);
            });
        }
    }
}
