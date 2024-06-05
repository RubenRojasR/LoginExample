using LoginExample.Dal.EFC;
using LoginExample.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginExample.Services.DeviceSessions
{
    public class DeviceSessionRepository : IDeviceSessionRepository
    {
        private readonly ApplicationDbContextEFC _context;

        public DeviceSessionRepository(ApplicationDbContextEFC context)
        {
            _context = context;
        }
        public async Task AddDeviceSessionAsync(DeviceSession session)
        {
            _context.DeviceSessions.Add(session);
            await _context.SaveChangesAsync();
        }

        public async Task EndDeviceSessionAsync(int sessionId)
        {
            var session = await _context.DeviceSessions.FindAsync(sessionId);
            if (session != null)
            {
                session.SessionEnd = DateTime.UtcNow;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<DeviceSession>> GetActiveSessionsByUserAsync(string userId)
        {
            return await _context.DeviceSessions
           .Where(ds => ds.UserId == userId && ds.SessionEnd == null)
           .ToListAsync();
            
        }
    }
}
