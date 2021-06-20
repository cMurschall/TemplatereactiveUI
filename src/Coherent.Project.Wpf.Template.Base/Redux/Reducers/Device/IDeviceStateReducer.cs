using Coherent.Project.Wpf.Template.Base.Redux.States.Device;
using Redux;

namespace Coherent.Project.Wpf.Template.Base.Redux.Reducers.Device
{
    /// <summary>
    /// Redux reducer for the device state.
    /// </summary>
    public interface IDeviceStateReducer
    {
        /// <summary>
        /// Apply reduction from previous state and passed in actions
        /// </summary>
        /// <param name="previousState">Previous store state</param>
        /// <param name="reducerAction">Action to apply</param>
        /// <returns>Reduced/updated state</returns>
        DeviceState Reduce(DeviceState previousState, IAction reducerAction);
    }
}