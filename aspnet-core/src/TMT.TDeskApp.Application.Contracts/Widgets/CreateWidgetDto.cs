using System.ComponentModel.DataAnnotations;

namespace TMT.TDeskApp.Widgets
{
    public class CreateWidgetDto
    {
        [Required]
        public string Name { get; set; }
        public string Owner { get; set; }
        public string Logo { get; set; }
        public string WelcomeMessage { get; set; }
        public string TeamIntro { get; set; }
        public string PrimaryColor { get; set; }
        public string BackgroundColor { get; set; }      
        public string ObjectConfigs { get; set; }      
    }
}
