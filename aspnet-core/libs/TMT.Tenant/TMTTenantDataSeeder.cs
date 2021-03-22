using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;

namespace TMT.TenantManagement
{
    //TODO: Create a Volo.Abp.Data.Seeding namespace?
    public class TMTTenantDataSeeder : ITMTTenantDataSeeder, ITransientDependency
    {
        protected IServiceScopeFactory ServiceScopeFactory { get; }
        protected AbpDataSeedOptions Options { get; }

        public TMTTenantDataSeeder(
            IOptions<AbpDataSeedOptions> options,
            IServiceScopeFactory serviceScopeFactory)
        {
            ServiceScopeFactory = serviceScopeFactory;
            Options = options.Value;
        }

        [UnitOfWork]
        public virtual async Task SeedAsync(TMTTenantDataSeedContext context)
        {
            using (var scope = ServiceScopeFactory.CreateScope())
            {
                foreach (var contributorType in Options.Contributors)
                {
                    if (contributorType.Name.StartsWith("TMT"))
                    {
                        var contributor = (ITMTDataSeedContributor)scope
                            .ServiceProvider
                            .GetRequiredService(contributorType);

                        await contributor.SeedAsync(context);
                    }
                }
            }
        }

        [UnitOfWork]
        public virtual async Task SeedAsync(DataSeedContext context)
        {
            using (var scope = ServiceScopeFactory.CreateScope())
            {
                foreach (var contributorType in Options.Contributors)
                {
                    var contributor = (IDataSeedContributor)scope
                        .ServiceProvider
                        .GetRequiredService(contributorType);

                    await contributor.SeedAsync(context);
                }
            }
        }
    }
}
