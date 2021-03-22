using System;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.TenantManagement;

namespace TMT.TenantManagement.EntityFrameworkCore
{
    public static class TMTTenantManagementDbContextModelCreatingExtensions
    {
        public static void ConfigureTMTTenantManagement(
            this ModelBuilder builder,
            [CanBeNull] Action<TMTTenantManagementModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            if (builder.IsTenantOnlyDatabase())
            {
                return;
            }

            var options = new TMTTenantManagementModelBuilderConfigurationOptions(
                TMTTenantManagementDbProperties.DbTablePrefix,
                TMTTenantManagementDbProperties.DbSchema
            );

            optionsAction?.Invoke(options);

            builder.Entity<TMTTenant>(b =>
            {
                b.ToTable(options.TablePrefix + "Tenants", options.Schema);

                b.ConfigureByConvention();

                b.Property(t => t.Name).IsRequired().HasMaxLength(TMTTenantConsts.MaxNameLength);

                b.HasMany(u => u.ConnectionStrings).WithOne().HasForeignKey(uc => uc.TenantId).IsRequired();

                b.HasIndex(u => u.Name);
            });

            builder.Entity<TMTTenantConnectionString>(b =>
            {
                b.ToTable(options.TablePrefix + "TenantConnectionStrings", options.Schema);

                b.ConfigureByConvention();

                b.HasKey(x => new { x.TenantId, x.Name });

                b.Property(cs => cs.Name).IsRequired().HasMaxLength(TenantConnectionStringConsts.MaxNameLength);
                b.Property(cs => cs.Value).IsRequired().HasMaxLength(TenantConnectionStringConsts.MaxValueLength);
            });
        }
    }
}
