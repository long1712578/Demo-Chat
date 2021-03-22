using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Modularity;

namespace TMT.UniqueKey
{
    public class TMTUniqueKeyModule: AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            SkipAutoServiceRegistration = true;
        }
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddTransient<IUniqueKey,SequentialUniqueKeyGenerator>();
        }
    }
}
