using Coherent.Project.Wpf.Template.Base.Mediator.Requests.Device;
using Coherent.Project.Wpf.Template.Base.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Coherent.Project.Wpf.Template.Base.Mediator.RequestHandlers.Device
{
    public class DeviceDisconnectRequestHandler : IRequestHandler<DeviceDisconnectRequest, bool>
    {
        private readonly IDeviceService _deviceService;

        public DeviceDisconnectRequestHandler(IDeviceService deviceService)
        {
            _deviceService = deviceService;
        }


        public Task<bool> Handle(DeviceDisconnectRequest request, CancellationToken cancellationToken)
        {
            return _deviceService.Disconnect(cancellationToken);
        }
    }
}