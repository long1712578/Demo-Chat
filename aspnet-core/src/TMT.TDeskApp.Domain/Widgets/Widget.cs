using TMT.Auditing;
using TMT.TenantManagement;
using TMT.UniqueKey;

namespace TMT.TDeskApp.Widgets
{
    public class Widget: TMTFullAuditedAggregateRoot<string>, ITMTMultiTenant
    {       
        public string Name { get; set; }
        public string Owner { get; set; }
        public string Logo { get; set; }
        public string WelcomeMessage { get; set; }
        public string TeamIntro { get; set; }
        public string PrimaryColor { get; set; }
        public string BackgroundColor { get; set; }      
        public string ObjectConfigs { get; set; }
        public string TenantId { get; }

        public Widget(
            string name,
            string owner,
            string logo,
            string welcomeMessage,
            string primaryColor,
            string teamIntro,
            string backgroundColor,
            string objectConfigs)
        {
            Name = name;
            Owner = owner;
            Logo = logo;
            WelcomeMessage = welcomeMessage;
            PrimaryColor = primaryColor;
            TeamIntro = teamIntro;            
            BackgroundColor = backgroundColor;
            ObjectConfigs = objectConfigs;
            var generator = new SequentialUniqueKeyGenerator();
            this.Id = generator.Create();
        }

        public Widget()
        {
            var generator = new SequentialUniqueKeyGenerator();
            this.Id = generator.Create();
        }
    }
}
