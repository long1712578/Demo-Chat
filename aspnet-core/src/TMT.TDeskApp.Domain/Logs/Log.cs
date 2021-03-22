using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMT.Auditing;

namespace TMT.TDeskApp.Logs
{
    public class Log: TMTFullAuditedAggregateRoot<string>
    {
        //public DateTime CreatedTime { get; set; }
        public string SessionId { get; set; }
        public string IpAddress { get; set; }
        public string UserAgent { get; set; }
        public string Cookies { get; set; }
        public string Browser { get; set; }
        public string OS { get; set; }
    }
}
