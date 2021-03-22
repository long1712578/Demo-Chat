using System;
using JetBrains.Annotations;

namespace TMT.TenantManagement
{
    public class TMTBasicTenantInfo
    {
        /// <summary>
        /// Null indicates the host.
        /// Not null value for a tenant.
        /// </summary>
        [CanBeNull]
        public string TenantId { get; }

        /// <summary>
        /// Name of the tenant if <see cref="TenantId"/> is not null.
        /// </summary>
        [CanBeNull]
        public string Name { get; }

        public TMTBasicTenantInfo(string tenantId, string name = null)
        {
            TenantId = tenantId;
            Name = name;
        }
    }
}