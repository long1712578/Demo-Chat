using System;
using Volo.Abp.ObjectExtending.Modularity;

namespace TMT.TenantManagement.ObjectExtending
{
    public static class TMTTenantManagementModuleExtensionConfigurationDictionaryExtensions
    {
        public static ModuleExtensionConfigurationDictionary ConfigureTMTTenantManagement(
            this ModuleExtensionConfigurationDictionary modules,
            Action<TMTTenantManagementModuleExtensionConfiguration> configureAction)
        {
            return modules.ConfigureModule(
                TMTTenantManagementModuleExtensionConsts.ModuleName,
                configureAction
            );
        }
    }
}