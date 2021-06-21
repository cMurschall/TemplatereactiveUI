using System.Threading;
using System.Threading.Tasks;

namespace Coherent.Project.Wpf.Template.Base.Services
{
    public interface IDeviceService
    {
        /// <summary>
        ///     Connects to the device
        /// </summary>
        /// <param name="token">Cancellation token </param>
        /// <returns>True on success</returns>
        Task<bool> Connect(CancellationToken token);

        /// <summary>
        ///     Disconnect to the device
        /// </summary>
        /// <param name="token">Cancellation token </param>
        /// <returns>True on success</returns>
        Task<bool> Disconnect(CancellationToken token);


        /// <summary>
        ///     Sets a value on the device
        /// </summary>
        /// <param name="value">New value to set on device</param>
        /// <param name="token">Cancellation token </param>
        /// <returns>True on success</returns>
        Task<bool> SetValue(double value, CancellationToken token);
    }
}