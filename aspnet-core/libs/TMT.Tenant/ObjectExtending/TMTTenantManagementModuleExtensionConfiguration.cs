using System;
using Volo.Abp.ObjectExtending.Modularity;

namespace TMT.TenantManagement.ObjectExtending
{
    public class TMTTenantManagementModuleExtensionConfiguration : ModuleExtensionConfiguration
    {
        public TMTTenantManagementModuleExtensionConfiguration ConfigureTenant(
            Action<EntityExtensionConfiguration> configureAction)
        {
            return this.ConfigureEntity(
                TMTTenantManagementModuleExtensionConsts.EntityNames.Tenant,
                configureAction
            );
        }
    }
}