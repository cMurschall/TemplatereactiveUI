using Coherent.Project.Wpf.Template.Base.Mediator.Requests.Device;
using Coherent.Project.Wpf.Template.Base.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Coherent.Project.Wpf.Template.Base.Mediator.RequestHandlers.Device
{
    public class DeviceConnectRequestHandler : IRequestHandler<DeviceConnectRequest, bool>
    {

        private readonly IDeviceService _deviceService;

        public DeviceConnectRequestHandler(IDeviceService deviceService)
        {
            _deviceService = deviceService;
        }


        public Task<bool> Handle(DeviceConnectRequest request, CancellationToken cancellationToken)
            => _deviceService.Connect( cancellationToken);
    }
}