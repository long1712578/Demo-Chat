using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace TMT.TenantManagement.EntityFrameworkCore
{
    public class TMTTenantManagementModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public TMTTenantManagementModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix,
            [CanBeNull] string schema)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}