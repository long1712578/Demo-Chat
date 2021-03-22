using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.MultiTenancy;
using Volo.Abp.TenantManagement;
using TMT.TenantManagement.ObjectExtending;

namespace TMT.TenantManagement.EntityFrameworkCore
{
    [IgnoreMultiTenancy]
    [ConnectionStringName(TMTTenantManagementDbProperties.ConnectionStringName)]
    public class TMTTenantManagementDbContext : AbpDbContext<TMTTenantManagementDbContext>, ITMTTenantManagementDbContext
    {
        public DbSet<TMTTenant> Tenants { get; set; }

        public DbSet<TMTTenantConnectionString> TenantConnectionStrings { get; set; }

        public TMTTenantManagementDbContext(DbContextOptions<TMTTenantManagementDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureTMTTenantManagement();
        }
    }
}
