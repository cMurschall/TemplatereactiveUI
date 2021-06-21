using Coherent.Project.Wpf.Template.Base.Redux.States.Device;

namespace Coherent.Project.Wpf.Template.Base.Redux.States
{
    /// <summary>
    ///     Holds all the states of the application.
    ///     Feel free to add more states and include the generation in the
    ///     <see cref="CreateInitialState" /> method.
    /// </summary>
    public class ApplicationState
    {
        /// <summary>
        ///     Gets or sets the device state
        /// </summary>
        public DeviceState DeviceState { get; set; }


        /// <summary>
        ///     Create initial application state
        /// </summary>
        /// <returns>Initial state</returns>
        public static ApplicationState CreateInitialState()
        {
            return new() {DeviceState = DeviceState.CreateInitialState()};
        }
    }
}