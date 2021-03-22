using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace TMT.TDeskApp
{
    [Dependency(ReplaceServices = true)]
    public class TDeskAppBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "TDeskApp";
    }
}
