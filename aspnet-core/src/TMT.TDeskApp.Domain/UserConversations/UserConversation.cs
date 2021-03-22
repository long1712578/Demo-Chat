using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMT.Auditing;
using TMT.TenantManagement;

namespace TMT.TDeskApp.UserConversations
{
    public class UserConversation: TMTFullAuditedAggregateRoot<string>, ITMTMultiTenant
    {
        public string Status { get; set; }
        public string SeenFlag { get; set; }
        public string TimeStamp { get; set; }

        public string ConversationId { get; set; }
        public string TenantId { get; }
    }
}
