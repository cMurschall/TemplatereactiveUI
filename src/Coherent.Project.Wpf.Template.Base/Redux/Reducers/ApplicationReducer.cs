using Coherent.Project.Wpf.Template.Base.Redux.Reducers.Device;
using Coherent.Project.Wpf.Template.Base.Redux.States;
using Redux;
using System;

namespace Coherent.Project.Wpf.Template.Base.Redux.Reducers
{
    public class ApplicationReducer : IApplicationReducer
    {
        private readonly IDeviceStateReducer _deviceStateReducer;

        /// <summary>
        ///     Creates a new Application reducer. All sub reducers need to be injected here
        /// </summary>
        /// <param name="deviceStateReducer">Reducer of the device state</param>
        public ApplicationReducer(IDeviceStateReducer deviceStateReducer)
        {
            _deviceStateReducer = deviceStateReducer ?? throw new ArgumentNullException(nameof(deviceStateReducer));
        }

        /// <summary>
        ///     Reduces the new application state
        /// </summary>
        /// <param name="previousState">Last known state</param>
        /// <param name="action">Update action</param>
        /// <returns>A new state with the update action applied</returns>
        public ApplicationState Reduce(ApplicationState previousState, IAction action)
        {
            return new() {DeviceState = _deviceStateReducer.Reduce(previousState.DeviceState, action)};
        }
    }
}