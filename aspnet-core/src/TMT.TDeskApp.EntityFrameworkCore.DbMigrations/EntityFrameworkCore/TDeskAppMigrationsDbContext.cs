using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using TMT.TenantManagement.EntityFrameworkCore;

namespace TMT.TDeskApp.EntityFrameworkCore
{
    /* This DbContext is only used for database migrations.
     * It is not used on runtime. See TDeskAppDbContext for the runtime DbContext.
     * It is a unified model that includes configuration for
     * all used modules and your application.
     */
    public class TDeskAppMigrationsDbContext : AbpDbContext<TDeskAppMigrationsDbContext>
    {
        public TDeskAppMigrationsDbContext(DbContextOptions<TDeskAppMigrationsDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* Include modules to your migration db context */

            builder.ConfigurePermissionManagement();
            builder.ConfigureSettingManagement();
            builder.ConfigureBackgroundJobs();
            builder.ConfigureAuditLogging();
            builder.ConfigureFeatureManagement();
            builder.ConfigureTMTTenantManagement();

            /* Configure your own tables/entities inside the ConfigureTDeskApp method */

            builder.ConfigureTDeskApp();
        }
    }
}