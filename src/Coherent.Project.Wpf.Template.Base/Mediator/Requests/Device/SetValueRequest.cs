using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coherent.Project.Wpf.Template.Base.Mediator.Requests.Device
{
    /// <summary>
    /// Request to set the value of the device
    /// </summary>
    public class SetValueRequest : IRequest<bool>
    {
        /// <summary>
        /// Value to set on the device
        /// </summary>
        public double Value { get; set; }
    }
}
