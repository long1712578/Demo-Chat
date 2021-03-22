using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TMT.TenantManagement;
using Volo.Abp.Domain.Repositories;

namespace TMT.TenantManagement
{
    public interface ITMTTenantRepository : IBasicRepository<TMTTenant, string>
    {
        Task<TMTTenant> FindByNameAsync(
            string name,
            bool includeDetails = true,
            CancellationToken cancellationToken = default);

        [Obsolete("Use FindByNameAsync method.")]
        TMTTenant FindByName(
            string name,
            bool includeDetails = true
        );

        [Obsolete("Use FindAsync method.")]
        TMTTenant FindById(
            string id,
            bool includeDetails = true
        );

        Task<List<TMTTenant>> GetListAsync(
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            string filter = null,
            bool includeDetails = false,
            CancellationToken cancellationToken = default);

        Task<long> GetCountAsync(
            string filter = null,
            CancellationToken cancellationToken = default);
    }
}
