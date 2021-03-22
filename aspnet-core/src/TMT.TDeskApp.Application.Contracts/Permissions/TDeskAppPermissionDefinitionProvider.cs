using TMT.TDeskApp.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace TMT.TDeskApp.Permissions
{
    public class TDeskAppPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(TDeskAppPermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(TDeskAppPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<TDeskAppResource>(name);
        }
    }
}
