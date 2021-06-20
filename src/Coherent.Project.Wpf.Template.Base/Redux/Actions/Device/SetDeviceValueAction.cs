using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redux;

namespace Coherent.Project.Wpf.Template.Base.Redux.Actions.Device
{
    public class SetDeviceValueAction : IAction
    {
        public double Value { get; set; }
    }
}
