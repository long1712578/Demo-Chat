using System.Threading.Tasks;
using TMT.TenantManagement;
using Volo.Abp.Data;

namespace TMT.TenantManagement
{
    public interface ITMTDataSeedContributor : IDataSeedContributor
    {
        Task SeedAsync(TMTTenantDataSeedContext context);
    }
}