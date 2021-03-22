using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace TMT.TDeskApp.EntityFrameworkCore
{
    [DependsOn(
        typeof(TDeskAppEntityFrameworkCoreModule)
        )]
    public class TDeskAppEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<TDeskAppMigrationsDbContext>();
        }
    }
}
