using TMT.TDeskApp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace TMT.TDeskApp
{
    [DependsOn(
        typeof(TDeskAppEntityFrameworkCoreTestModule)
        )]
    public class TDeskAppDomainTestModule : AbpModule
    {

    }
}