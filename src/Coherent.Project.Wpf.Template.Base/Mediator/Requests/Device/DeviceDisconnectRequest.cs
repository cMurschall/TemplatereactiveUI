using MediatR;

namespace Coherent.Project.Wpf.Template.Base.Mediator.Requests.Device
{
    /// <summary>
    ///     Request to disconnect to the device
    /// </summary>
    public class DeviceDisconnectRequest : IRequest<bool>
    {
    }
}