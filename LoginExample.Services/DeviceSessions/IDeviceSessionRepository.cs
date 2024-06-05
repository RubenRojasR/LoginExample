using LoginExample.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginExample.Services.DeviceSessions
{
    public interface IDeviceSessionRepository
    {
        Task AddDeviceSessionAsync(DeviceSession session);
        Task<List<DeviceSession>> GetActiveSessionsByUserAsync(string userId);
        Task EndDeviceSessionAsync(int sessionId);
    }
}
