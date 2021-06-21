using Coherent.Project.Wpf.Template.Base.Mediator.Requests.Device;
using Coherent.Project.Wpf.Template.Base.Redux.States;
using Coherent.Project.Wpf.Template.Base.Redux.States.Device;
using MediatR;
using ReactiveUI;
using Redux;
using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Unit = System.Reactive.Unit;

namespace Coherent.Project.Wpf.Template.Gui.ViewModels
{
    public class MainViewModel : ActivatableViewModelBase
    {
        private readonly IMediator _mediator;
        private readonly Random _random = new();


        // ReSharper disable once SuggestBaseTypeForParameter (DI will fail otherwise)
        public MainViewModel(IStore<ApplicationState> store, IMediator mediator)
        {
            ApplicationState = store ?? throw new ArgumentNullException(nameof(store));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));


            this.WhenActivated(disposables => {
                HandleActivation();


                // canExecute observable example
                var canExecuteUpdateDeviceValue = store.Select(x => x.DeviceState.DeviceType != DeviceType.Unknown);
                // create the device update command
                UpdateDeviceValue = ReactiveCommand.CreateFromTask(token =>
                        mediator.Send(new SetValueRequest { Value = _random.Next(10, 100) }, token), canExecuteUpdateDeviceValue.ObserveOn(RxApp.MainThreadScheduler))
                    .DisposeWith(disposables);



                Disposable
                    .Create(HandleDeactivation)
                    .DisposeWith(disposables);
            });
        }

        /// <summary>
        ///     Gets the application state as an IObservable
        /// </summary>
        public IObservable<ApplicationState> ApplicationState { get; }


        /// <summary>
        ///     Gets a command that assigns a new value to the device
        /// </summary>
        public ReactiveCommand<Unit, bool> UpdateDeviceValue { get; private set; }

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