using Redux;

namespace Coherent.Project.Wpf.Template.Base.Redux.Actions.Device
{
    /// <summary>
    ///     Redux action to update the device value
    /// </summary>
    public class SetDeviceValueAction : IAction
    {
        /// <summary>
        ///     Gets or sets the new device value
        /// </summary>
        public double Value { get; set; }
    }
}