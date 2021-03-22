using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TMT.TenantManagement.EntityFrameworkCore
{
    public static class TMTTenantManagementEfCoreQueryableExtensions
    {
        public static IQueryable<TMTTenant> IncludeDetails(this IQueryable<TMTTenant> queryable, bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            return queryable
                .Include(x => x.ConnectionStrings);
        }
    }
}