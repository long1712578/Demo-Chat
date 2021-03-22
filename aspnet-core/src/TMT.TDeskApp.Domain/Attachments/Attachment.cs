using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMT.Auditing;
using TMT.TenantManagement;

namespace TMT.TDeskApp.Attachments
{
    public class Attachment : TMTFullAuditedAggregateRoot<string>, ITMTMultiTenant
    {
        public string TenantId { get; }
        public string ConversationId { get; set; }
        public string MessageId { get; set; }

        public string Content { get; set; }
        public string Size { get; set; }    
        public string FileType { get; set; }
        //public DateTime CreateAt { get; set; } = DateTime.Now;
        //public DateTime UpdateAt { get; set; }
        public string Status { get; set; }
        public string CreateById { get; set; }
        public string FilePath { get; set; }
        public string FileUrl { get; set; }
    }
}
