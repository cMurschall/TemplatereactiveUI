// unset

using Coherent.Project.Wpf.Template.Base.Redux.States.Device;
using Redux;

namespace Coherent.Project.Wpf.Template.Base.Redux.Actions.Device
{
    /// <summary>
    ///     Redux action to update the device type state
    /// </summary>
    public class SetDeviceTypeAction : IAction
    {
        /// <summary>
        ///     Gets or sets the new device type
        /// </summary>
        public DeviceType DeviceType { get; set; }
    }
}