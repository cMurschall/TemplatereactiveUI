using Coherent.Project.Wpf.Template.Base.Redux.States.Device;
using Coherent.Project.Wpf.Template.Gui.ViewModels;
using ReactiveUI;
using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace Coherent.Project.Wpf.Template.Gui.Views
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow(MainViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;


            this.WhenActivated(disposables => {
                viewModel.ApplicationState
                    .Select(x => x.DeviceState.DeviceValue)
                    .DistinctUntilChanged()
                    .ObserveOn(RxApp.MainThreadScheduler)
                    .Select(value => $"Device value: {value:F3}")
                    .BindTo(this, view => view.DeviceValue.Text)
                    .DisposeWith(disposables);


                viewModel.ApplicationState
                    .Select(x => x.DeviceState.DeviceType)
                    .DistinctUntilChanged()
                    .ObserveOn(RxApp.MainThreadScheduler)
                    .Select<DeviceType, ReactiveObject>(type => type switch {
                        // return the appropriate viewmodel depending of the DeviceType enum.
                        DeviceType.DeviceA => new DeviceAViewModel(),
                        DeviceType.DeviceB => new DeviceBViewModel(),
                        DeviceType.Unknown => null,
                        _ => null
                    })
                    .BindTo(this, view => view.DeviceViewModelViewHost.ViewModel)
                    .DisposeWith(disposables);


                this.OneWayBind(ViewModel, vm => vm.UpdateDeviceValue, view => view.DeviceNewValueButton.Command)
                    .DisposeWith(disposables);

            });
        }
    }
}