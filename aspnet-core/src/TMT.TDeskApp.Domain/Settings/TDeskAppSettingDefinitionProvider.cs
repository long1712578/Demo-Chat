using Volo.Abp.Settings;

namespace TMT.TDeskApp.Settings
{
    public class TDeskAppSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(TDeskAppSettings.MySetting1));
        }
    }
}
