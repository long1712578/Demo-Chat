using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMT.Auditing;
using TMT.TenantManagement;

namespace TMT.TDeskApp.UserGroups
{
    public class UserGroup: TMTFullAuditedAggregateRoot<string>, ITMTMultiTenant
    {
        public string Name { get; set; }
        public string RoleId { get; set; }

        public string TenantId { get; }
    }
}
