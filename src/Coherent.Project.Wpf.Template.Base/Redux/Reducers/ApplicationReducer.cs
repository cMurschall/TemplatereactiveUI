using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coherent.Project.Wpf.Template.Base.Redux.Reducers.Device;
using Coherent.Project.Wpf.Template.Base.Redux.States;
using Redux;

namespace Coherent.Project.Wpf.Template.Base.Redux.Reducers
{
    public class ApplicationReducer : IApplicationReducer
    {

        private readonly IDeviceStateReducer _deviceStateReducer;


        public ApplicationReducer(IDeviceStateReducer deviceStateReducer)
        {
            _deviceStateReducer = deviceStateReducer ?? throw new ArgumentNullException(nameof(deviceStateReducer));
        }


        public ApplicationState Reduce(ApplicationState previousState, IAction action)
        {
            return new()
            {
                DeviceState = _deviceStateReducer.Reduce(previousState.DeviceState, action),
            };
        }
    }
}
