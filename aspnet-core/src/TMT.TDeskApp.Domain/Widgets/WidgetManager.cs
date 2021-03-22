using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace TMT.TDeskApp.Widgets
{
    public class WidgetManager : DomainService
    {
        private readonly IWidgetRepository _widgetRepository;
        public WidgetManager(IWidgetRepository widgetRepository)
        {
            _widgetRepository = widgetRepository;
        }
        public async Task CreateWidget(
            string name, 
            string owner, 
            string logo, 
            string welcomeMessage,
            string primaryColor,
            string teamIntro,
            string backgroundColor,
            string objectConfigs)
        {
            var entity = new Widget(name, owner, logo, welcomeMessage, teamIntro, primaryColor,  backgroundColor, objectConfigs);

            await _widgetRepository.InsertAsync(entity);
            await _widgetRepository.SaveChange();
        }                   
    }
}
