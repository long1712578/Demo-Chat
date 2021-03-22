using System;
using System.Collections.Generic;
using System.Text;

namespace TMT.TenantManagement
{
    public interface ITMTMultiTenant
    {
        string TenantId { get; }
    }
}
