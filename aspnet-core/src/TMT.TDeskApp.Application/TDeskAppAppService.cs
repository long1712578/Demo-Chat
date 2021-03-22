using System;
using System.Collections.Generic;
using System.Text;
using TMT.TDeskApp.Localization;
using Volo.Abp.Application.Services;

namespace TMT.TDeskApp
{
    /* Inherit your application services from this class.
     */
    public abstract class TDeskAppAppService : ApplicationService
    {
        protected TDeskAppAppService()
        {
            LocalizationResource = typeof(TDeskAppResource);
        }
    }
}
