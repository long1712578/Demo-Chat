using Volo.Abp.DependencyInjection;

namespace TMT.TenantManagement
{
    [Dependency(ReplaceServices = true)]
    public class TMTWebAssemblyCurrentTenantAccessor : ITMTCurrentTenantAccessor, ISingletonDependency
    {
        public TMTBasicTenantInfo Current { get; set; }
    }
}
