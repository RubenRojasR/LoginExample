using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginExample.Models.DTOs
{
    public class DeviceSessionDTO
    {
        public string UserId { get; set; }
        public string DeviceName { get; set; }
        public string IpAddress { get; set; }
    }
}
