using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMT.Auditing;
using TMT.TenantManagement;

namespace TMT.TDeskApp.LabelConversations
{
    public class LabelConversation: TMTFullAuditedAggregateRoot<string>, ITMTMultiTenant
    {
        public string UserCreate { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }

        public string LabelId { get; set; }
        public string ConversationId { get; set; }
        public string TenantId { get; }
    }
}
