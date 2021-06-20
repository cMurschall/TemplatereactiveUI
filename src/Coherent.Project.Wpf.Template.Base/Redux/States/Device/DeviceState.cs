using System;

namespace Coherent.Project.Wpf.Template.Base.Redux.States.Device
{
    /// <summary>
    /// Holds the internal state of the device.
    /// Replace / extend this class with appropriate properties.
    /// </summary>
    public class DeviceState : ICloneable
    {

        /// <summary>
        /// Gets or sets the device value
        /// Replace with real properties and meaningful default values.
        /// </summary>
        public double DeviceValue { get; set; } = double.NaN;


        /// <inheritdoc />
        public object Clone() => MemberwiseClone();

        /// <summary>
        /// Creates the initial state of <see cref="DeviceState"/>.
        /// </summary>
        /// <returns>A new  state with initial values.</returns>
        public static DeviceState CreateInitialState() => new();
    }
}
