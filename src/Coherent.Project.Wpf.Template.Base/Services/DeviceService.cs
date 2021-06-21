// unset

using Coherent.Project.Wpf.Template.Base.Redux.Actions.Device;
using Coherent.Project.Wpf.Template.Base.Redux.States;
using Coherent.Project.Wpf.Template.Base.Redux.States.Device;
using Redux;
using System;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Coherent.Project.Wpf.Template.Base.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly Random _random = new();
        private readonly IStore<ApplicationState> _store;
        private double _deviceValue;

        private bool _isConnected;
        private IDisposable _updateTimer;


        public DeviceService(IStore<ApplicationState> store)
        {
            _store = store ?? throw new ArgumentNullException(nameof(store));
        }


        /// <inheritdoc />
        public async Task<bool> Connect(CancellationToken token)
        {
            if (_isConnected)
            {
                return true;
            }

            // fake some connection logic
            await Task.Delay(100, token);
            _isConnected = true;


            // start a once fetching device type call.
            _updateTimer = Observable.Timer(TimeSpan.FromSeconds(4))
                .Subscribe(_ => {
                    DeviceType deviceType = _random.NextDouble() < 0.5 ? DeviceType.DeviceA : DeviceType.DeviceB;

                    // publish our concluded device type to our application store
                    _store.Dispatch(new SetDeviceTypeAction {DeviceType = deviceType});
                });


            // start a fake update loop.
            _updateTimer = Observable
                .Interval(TimeSpan.FromSeconds(1)) // update device values every second
                .Subscribe(_ => {
                    // add some noise to our value (pretend we measured from some physical device)
                    double minNoise = -.1;
                    double maxNoise = +.1;
                    _deviceValue += (_random.NextDouble() * (maxNoise - minNoise)) + minNoise;

                    // publish our new value to our application store
                    _store.Dispatch(new SetDeviceValueAction {Value = _deviceValue});
                });

            return true;
        }


        /// <inheritdoc />
        public async Task<bool> Disconnect(CancellationToken token)
        {
            if (!_isConnected)
            {
                return false;
            }


            await Task.Delay(100, token);
            _isConnected = false;


            // stop update loop.
            _updateTimer.Dispose();

            return true;
        }


        /// <inheritdoc />
        public async Task<bool> SetValue(double value, CancellationToken token)
        {
            // fake some async connection to a device
            await Task.Delay(100, token);
            _deviceValue = value;

            return true;
        }
    }
}