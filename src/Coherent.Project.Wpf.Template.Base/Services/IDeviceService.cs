using Coherent.Project.Wpf.Template.Base.Redux.Actions.Device;
using Coherent.Project.Wpf.Template.Base.Redux.States;
using Redux;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Coherent.Project.Wpf.Template.Base.Services
{
    public interface IDeviceService
    {
        Task<bool> Connect(CancellationToken token);
        Task<bool> Disconnect(CancellationToken token);

        Task<bool> SetValue(double value, CancellationToken token);
    }

    public class DeviceService : IDeviceService
    {
        private readonly IStore<ApplicationState> _store;

        private bool _isConnected;

        private readonly Random _random = new();
        private double _deviceValue = 0;
        private IDisposable _updateTimer;



        public DeviceService(IStore<ApplicationState> store)
        {
            _store = store ?? throw new ArgumentNullException(nameof(store));
        }

        public async Task<bool> Connect(CancellationToken token)
        {
            if (_isConnected)
            {
                return true;
            }

            // fake some connection logic
            await Task.Delay(100, token);
            _isConnected = true;



            // start a fake update loop.
            _updateTimer = Observable
                 .Interval(TimeSpan.FromSeconds(1))// update device values every second
                 .Subscribe(_ => {
                    // add some noise to our value (pretend we measured from some physical device)
                    var minNoise = -.1;
                    var maxNoise = +.1;
                    _deviceValue += _random.NextDouble() * (maxNoise - minNoise) + minNoise;

                     // publish our new value to our application store
                     _store.Dispatch(new SetDeviceValueAction { Value = _deviceValue });
                 });

            return true;
        }

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

        public async Task<bool> SetValue(double value, CancellationToken token)
        {
            // fake some async connection to a device
            await Task.Delay(100, token);
            _deviceValue = value;

            return true;
        }


    }
}
