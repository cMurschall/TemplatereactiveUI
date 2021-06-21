using ReactiveUI;
using System.Reactive.Disposables;

namespace Coherent.Project.Wpf.Template.Gui.Views
{
    /// <summary>
    ///     Interaction logic for DeviceBView.xaml
    /// </summary>
    public partial class DeviceBView
    {
        public DeviceBView()
        {
            InitializeComponent();

            this.WhenActivated(disposables => {
                this.OneWayBind(ViewModel, vm => vm.DeviceBDescriptor, view => view.DeviceNameLabel.Content)
                    .DisposeWith(disposables);
            });
        }
    }
}