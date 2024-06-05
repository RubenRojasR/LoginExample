using LoginExample.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginExample.Services.DeviceSessions
{
    public class DeviceSessionService
    {
        private readonly IDeviceSessionRepository _deviceSessionRepository;

        public DeviceSessionService(IDeviceSessionRepository deviceSessionRepository)
        {
            _deviceSessionRepository = deviceSessionRepository;
        }

        public async Task AddDeviceSessionAsync(string userId, string deviceName, string ipAddress)
        {
            var session = new DeviceSession
            {
                UserId = userId,
                DeviceName = deviceName,
                IpAddress = ipAddress,
                SessionStart = DateTime.UtcNow
            };

            await _deviceSessionRepository.AddDeviceSessionAsync(session);
        }

        public async Task<List<DeviceSession>> GetActiveSessionsByUserAsync(string userId)
        {
            return await _deviceSessionRepository.GetActiveSessionsByUserAsync(userId);
        }

        public async Task EndDeviceSessionAsync(int sessionId)
        {
            await _deviceSessionRepository.EndDeviceSessionAsync(sessionId);
        }
    }
}
