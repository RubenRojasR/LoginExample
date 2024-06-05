using LoginExample.Models.DTOs;
using LoginExample.Services.DeviceSessions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoginExample.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceSessionsController : ControllerBase
    {
        private readonly DeviceSessionService _deviceSessionService;

        public DeviceSessionsController(DeviceSessionService deviceSessionService)
        {
            _deviceSessionService = deviceSessionService;
        }

        [HttpPost]
        public async Task<IActionResult> StartSession([FromBody] DeviceSessionDTO sessionDto)
        {
            await _deviceSessionService.AddDeviceSessionAsync(sessionDto.UserId, sessionDto.DeviceName, sessionDto.IpAddress);
            return Ok();
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetActiveSessions(string userId)
        {
            var sessions = await _deviceSessionService.GetActiveSessionsByUserAsync(userId);
            return Ok(sessions);
        }

        [HttpPost("{sessionId}/end")]
        public async Task<IActionResult> EndSession(int sessionId)
        {
            await _deviceSessionService.EndDeviceSessionAsync(sessionId);
            return Ok();
        }
    }
}
