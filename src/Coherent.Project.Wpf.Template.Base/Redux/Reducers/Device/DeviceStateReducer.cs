using Coherent.Project.Wpf.Template.Base.Redux.Actions.Device;
using Coherent.Project.Wpf.Template.Base.Redux.States.Device;
using Redux;

namespace Coherent.Project.Wpf.Template.Base.Redux.Reducers.Device
{
    /// <inheritdoc cref="IDeviceStateReducer" />
    public class DeviceStateReducer : BaseReducer<DeviceState>, IDeviceStateReducer
    {
        /// <inheritdoc />
        public DeviceState Reduce(DeviceState previousState, IAction reducerAction)
        {
            return reducerAction switch {
                SetDeviceValueAction action => UpdateClone(previousState, state => state.DeviceValue = action.Value),
                SetDeviceTypeAction action => UpdateClone(previousState, state => state.DeviceType = action.DeviceType),
                _ => previousState // noting to reduce for us
            };
        }
    }
}