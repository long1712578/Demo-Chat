using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.MultiTenancy;
using Volo.Abp.TenantManagement;

namespace TMT.TenantManagement.EntityFrameworkCore
{
    [IgnoreMultiTenancy]
    [ConnectionStringName(TMTTenantManagementDbProperties.ConnectionStringName)]
    public interface ITMTTenantManagementDbContext : IEfCoreDbContext
    {
        DbSet<TMTTenant> Tenants { get; }

        DbSet<TMTTenantConnectionString> TenantConnectionStrings { get; }
    }
}
