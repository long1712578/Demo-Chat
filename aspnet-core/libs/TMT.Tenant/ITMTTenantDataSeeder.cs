using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;

namespace TMT.TenantManagement
{
    public interface ITMTTenantDataSeeder : IDataSeeder
    {
        Task SeedAsync(TMTTenantDataSeedContext context);
    }
}
