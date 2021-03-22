using Volo.Abp.Data;

namespace TMT.TenantManagement
{
    public static class TMTTenantManagementDbProperties
    {
        public static string DbTablePrefix { get; set; } = "App";

        public static string DbSchema { get; set; } = AbpCommonDbProperties.DbSchema;

        public const string ConnectionStringName = "TMTTenantManagement";
    }
}
