using Microsoft.Extensions.DependencyInjection;
using TMT.TenantManagement;
using TMT.TenantManagement.EntityFrameworkCore;
using TMT.TenantManagement.ObjectExtending;
using Volo.Abp.AutoMapper;
using Volo.Abp.Caching;
using Volo.Abp.Data;
using Volo.Abp.Domain;
using Volo.Abp.Domain.Entities.Events.Distributed;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.ObjectExtending;
using Volo.Abp.ObjectExtending.Modularity;
using Volo.Abp.TenantManagement;
using Volo.Abp.Threading;

namespace TMT.TenantManagement
{
    [DependsOn(typeof(AbpMultiTenancyModule))]
    [DependsOn(typeof(AbpTenantManagementDomainSharedModule))]
    [DependsOn(typeof(AbpDataModule))]
    [DependsOn(typeof(AbpDddDomainModule))]
    [DependsOn(typeof(AbpAutoMapperModule))]
    [DependsOn(typeof(AbpCachingModule))]
    [DependsOn(typeof(AbpEntityFrameworkCoreModule))]
    public class TMTTenantManagementModule : AbpModule
    {
        private static readonly OneTimeRunner OneTimeRunner = new OneTimeRunner();

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<TMTTenantManagementModule>();

            context.Services.AddAbpDbContext<TMTTenantManagementDbContext>(options =>
            {
                options.AddDefaultRepositories<ITMTTenantManagementDbContext>();
            });

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<TMTTenantManagementMappingProfile>(validate: true);
            });

            Configure<AbpDistributedEntityEventOptions>(options =>
            {
                options.EtoMappings.Add<TMTTenant, TMTTenantEto>();
            });

            context.Services.AddSingleton<ITMTCurrentTenantAccessor, TMTWebAssemblyCurrentTenantAccessor>();

            context.Services.AddTransient<ITMTTenantRepository, TMTEfCoreTenantRepository>();
            context.Services.AddTransient<ITMTCurrentTenant, TMTCurrentTenant>();
        }

        public override void PostConfigureServices(ServiceConfigurationContext context)
        {
            OneTimeRunner.Run(() =>
            {
                ModuleExtensionConfigurationHelper.ApplyEntityConfigurationToEntity(
                    TMTTenantManagementModuleExtensionConsts.ModuleName,
                    TMTTenantManagementModuleExtensionConsts.EntityNames.Tenant,
                    typeof(TMTTenant)
                );
            });
        }
    }
}
