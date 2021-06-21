using MediatR;

namespace Coherent.Project.Wpf.Template.Base.Mediator.Requests.Device
{
    /// <summary>
    ///     Request to set the value of the device
    /// </summary>
    public class SetValueRequest : IRequest<bool>
    {
        /// <summary>
        ///     Value to set on the device
        /// </summary>
        public double Value { get; set; }
    }
}