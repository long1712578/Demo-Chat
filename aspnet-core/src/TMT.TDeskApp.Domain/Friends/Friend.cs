using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace TMT.TDeskApp.Friends
{
    public class Friend : FullAuditedAggregateRoot<string>
    {
        public string UserSend { get; set; }
        public string UserRecive { get; set; }
        public DateTime? SendDate { get; set; }
        public DateTime? AcceptDate { get; set; }
        public DateTime? CancleDate { get; set; }

    }
}
