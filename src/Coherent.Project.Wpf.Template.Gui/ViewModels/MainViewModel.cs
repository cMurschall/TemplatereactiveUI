using Coherent.Project.Wpf.Template.Base.Mediator.Requests.Device;
using Coherent.Project.Wpf.Template.Base.Redux.States;
using MediatR;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Redux;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Unit = System.Reactive.Unit;

namespace Coherent.Project.Wpf.Template.Gui.ViewModels
{
    public class MainViewModel : ReactiveObject, IActivatableViewModel
    {
        private readonly IStore<ApplicationState> _store;
        private readonly IMediator _mediator;

        private Random _random = new Random();
        public ViewModelActivator Activator { get; }


        [ObservableAsProperty]
        // ReSharper disable once UnassignedGetOnlyAutoProperty
        public double DeviceValue { get; }


        public ReactiveCommand<Unit, bool> UpdateDeviceValue { get; }


        public MainViewModel(IStore<ApplicationState> store, IMediator mediator)
        {
            _store = store;
            _mediator = mediator;

            Activator = new ViewModelActivator();

            UpdateDeviceValue = ReactiveCommand.CreateFromTask( token => mediator.Send(new SetValueRequest {Value = _random.Next(10, 100)}, token));




            this.WhenActivated(disposables => {

                store
                          .Select(x => x.DeviceState.DeviceValue)
                          .DistinctUntilChanged()
                          .ObserveOn(RxApp.MainThreadScheduler)
                          .ToPropertyEx(this, x => x.DeviceValue)
                          .DisposeWith(disposables);



                HandleActivation();

                Disposable
                    .Create(HandleDeactivation)
                    .DisposeWith(disposables);
            });
        }

        private void HandleDeactivation()
        {
            _mediator.Send(new DeviceDisconnectRequest()).Wait();
        }

        private void HandleActivation()
        {
            _mediator.Send(new DeviceConnectRequest());
        }
    }
}
