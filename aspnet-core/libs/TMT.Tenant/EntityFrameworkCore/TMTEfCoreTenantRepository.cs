using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace TMT.TenantManagement.EntityFrameworkCore
{
    public class TMTEfCoreTenantRepository : EfCoreRepository<ITMTTenantManagementDbContext, TMTTenant, string>, ITMTTenantRepository
    {
        public TMTEfCoreTenantRepository(IDbContextProvider<ITMTTenantManagementDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task<TMTTenant> FindByNameAsync(
            string name,
            bool includeDetails = true,
            CancellationToken cancellationToken = default)
        {
            return await (await GetDbSetAsync())
                .IncludeDetails(includeDetails)
                .OrderBy(t => t.Id)
                .FirstOrDefaultAsync(t => t.Name == name, GetCancellationToken(cancellationToken));
        }

        [Obsolete("Use FindByNameAsync method.")]
        public virtual TMTTenant FindByName(string name, bool includeDetails = true)
        {
            return DbSet
                .IncludeDetails(includeDetails)
                .OrderBy(t => t.Id)
                .FirstOrDefault(t => t.Name == name);
        }

        [Obsolete("Use FindAsync method.")]
        public virtual TMTTenant FindById(string id, bool includeDetails = true)
        {
            return DbSet
                .IncludeDetails(includeDetails)
                .OrderBy(t => t.Id)
                .FirstOrDefault(t => t.Id == id);
        }

        public virtual async Task<List<TMTTenant>> GetListAsync(
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            string filter = null,
            bool includeDetails = false,
            CancellationToken cancellationToken = default)
        {
            return await (await GetDbSetAsync())
                .IncludeDetails(includeDetails)
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    u =>
                        u.Name.Contains(filter)
                )
                .OrderBy(sorting ?? nameof(TMTTenant.Name))
                .PageBy(skipCount, maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        public virtual async Task<long> GetCountAsync(string filter = null, CancellationToken cancellationToken = default)
        {
            return await this
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    u =>
                        u.Name.Contains(filter)
                ).CountAsync(cancellationToken: cancellationToken);
        }

        [Obsolete("Use WithDetailsAsync method.")]
        public override IQueryable<TMTTenant> WithDetails()
        {
            return GetQueryable().IncludeDetails();
        }

        public override async Task<IQueryable<TMTTenant>> WithDetailsAsync()
        {
            return (await GetQueryableAsync()).IncludeDetails();
        }
    }
}
