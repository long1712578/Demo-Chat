using Volo.Abp.Modularity;

namespace TMT.TDeskApp
{
    [DependsOn(
        typeof(TDeskAppApplicationModule),
        typeof(TDeskAppDomainTestModule)
        )]
    public class TDeskAppApplicationTestModule : AbpModule
    {

    }
}