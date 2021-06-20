using Coherent.Project.Wpf.Template.Base.Mediator.Requests.Device;
using Coherent.Project.Wpf.Template.Base.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Coherent.Project.Wpf.Template.Base.Mediator.RequestHandlers.Device
{
    public class SetValueRequestHandler : IRequestHandler<SetValueRequest, bool>
    {

        private readonly IDeviceService _deviceService;

        public SetValueRequestHandler(IDeviceService deviceService)
        {
            _deviceService = deviceService;
        }


        public Task<bool> Handle(SetValueRequest request, CancellationToken cancellationToken)
            => _deviceService.SetValue(request.Value, cancellationToken);
    }
}
