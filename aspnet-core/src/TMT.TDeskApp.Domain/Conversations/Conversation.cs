using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using TMT.TenantManagement;
using TMT.Auditing;
using TMT.UniqueKey;

namespace TMT.TDeskApp.Conversations
{
    public class Conversation : TMTAuditedAggregateRoot<string>, ITMTMultiTenant
    {
        public Conversation()
        {
            var generator = new SequentialUniqueKeyGenerator();
            this.Id = generator.Create();
        }

        public Conversation(string id, string note, string widgetId, string tenantId)
        {
            this.Id = id;
            this.Note = note;
            this.WidgetId = widgetId;
            this.TenantId = tenantId;
        }

        //public DateTime CreateAt { get; set; } = DateTime.Now;
        //public DateTime EndAt { get; set; }
        public string Url { get; set; }
        public string Browser { get; set; }
        public string OS { get; set; }
        public string IpAddress { get; set; }
        public string Status { get; set; }
        public string Note { get; set; }
        public string UserAgent { get; set; }
        public string FirstResponseAt { get; set; }

        public string UserGroupId { get; set; }
        public string WidgetId { get; set; }
        public string TenantId { get; }

    }
}
