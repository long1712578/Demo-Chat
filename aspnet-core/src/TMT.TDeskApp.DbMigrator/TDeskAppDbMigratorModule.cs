using TMT.TDeskApp.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace TMT.TDeskApp.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(TDeskAppEntityFrameworkCoreDbMigrationsModule),
        typeof(TDeskAppApplicationContractsModule)
        )]
    public class TDeskAppDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
