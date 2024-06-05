using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginExample.Models.Models
{
    public class DeviceSession
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string DeviceName { get; set; }
        public string IpAddress { get; set; }
        public DateTime SessionStart { get; set; }
        public DateTime? SessionEnd { get; set; }
    }
}
