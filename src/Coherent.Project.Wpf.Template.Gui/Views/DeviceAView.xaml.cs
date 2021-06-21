using ReactiveUI;
using System.Reactive.Disposables;

namespace Coherent.Project.Wpf.Template.Gui.Views
{
    /// <summary>
    ///     Interaction logic for DeviceAView.xaml
    /// </summary>
    public partial class DeviceAView
    {
        public DeviceAView()
        {
            InitializeComponent();

            this.WhenActivated(disposables => {
                this.OneWayBind(ViewModel, vm => vm.DeviceADescriptor, view => view.DeviceNameLabel.Content)
                    .DisposeWith(disposables);
            });
        }
    }
}