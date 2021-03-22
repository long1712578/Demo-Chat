using TMT.TDeskApp.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace TMT.TDeskApp.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class TDeskAppController : AbpController
    {
        protected TDeskAppController()
        {
            LocalizationResource = typeof(TDeskAppResource);
        }
    }
}