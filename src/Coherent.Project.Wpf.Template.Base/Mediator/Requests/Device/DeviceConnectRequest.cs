using MediatR;

namespace Coherent.Project.Wpf.Template.Base.Mediator.Requests.Device
{
    /// <summary>
    /// Request to connect to the device
    /// </summary>
    public class DeviceConnectRequest : IRequest<bool>
    {
    }
}