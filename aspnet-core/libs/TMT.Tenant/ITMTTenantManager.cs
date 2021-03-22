using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp.Domain.Services;

namespace TMT.TenantManagement
{
    public interface ITMTTenantManager : Volo.Abp.Domain.Services.IDomainService
    {
        [NotNull]
        Task<TMTTenant> CreateAsync([NotNull] string name);

        Task ChangeNameAsync([NotNull] TMTTenant tenant, [NotNull] string name);
    }
}
