using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMT.Auditing;
using TMT.TenantManagement;

namespace TMT.TDeskApp.Labels
{
    public class Label: TMTAuditedAggregateRoot<string>, ITMTMultiTenant
    {
        public string Name { get; set; }
        public string Color { get; set; }

        public string TenantId { get; }
    }
}
