using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMT.TDeskApp.Objects;
using TMT.TDeskApp.Widgets;
using Volo.Abp;
using Volo.Abp.Application.Services;

namespace TMT.TDeskApp.Services
{
    [RemoteService(IsEnabled = false)]
    public class WidgetService : ApplicationService, IWidgetService
    {
        private readonly IWidgetRepository _widgetRepository;
        private readonly WidgetManager _widgetManager;
        public WidgetService(IWidgetRepository widgetrepository, WidgetManager widgetManager)
        {
            _widgetRepository = widgetrepository;
            _widgetManager = widgetManager;
        }
        public async Task<List<WidgetDto>> GetAllWidget()
        {
            List<Widget> lstWid = await _widgetRepository.GetAll();
            var listWidDto = ObjectMapper.Map<List<Widget>, List<WidgetDto>>(lstWid);
            return listWidDto;
        }
        public async Task<ObjectResponse> CreateWidgetAsync(CreateWidgetDto input)
        {
            ObjectResponse reponse = new ObjectResponse();
            try
            {
                await _widgetManager.CreateWidget(
                input.Name,
                input.Owner,
                input.Logo,
                input.WelcomeMessage,
                input.PrimaryColor,
                input.TeamIntro,            
                input.BackgroundColor,
                input.ObjectConfigs
                );
               
                reponse.message = "Ok";
                return reponse;
            }
            catch (Exception ex)
            {
                var er = ex.Message;
                reponse.error.Add(er);
                return reponse;
            }
        }

        public async Task<ObjectResponse> UpdateWidgetAsync(string id, UpdateWidgetDto input)
        {
            ObjectResponse reponse = new ObjectResponse();
            try
            {
                var widget = await _widgetRepository.GetAsync(id);
                widget.Name = input.Name;
                widget.Owner = input.Owner;
                widget.Logo = input.Logo;
                widget.WelcomeMessage = input.WelcomeMessage;
                widget.TeamIntro = input.TeamIntro;
                widget.PrimaryColor = input.PrimaryColor;
                widget.BackgroundColor = input.BackgroundColor;
                widget.ObjectConfigs = input.ObjectConfigs;

                await _widgetRepository.UpdateAsync(widget);

                reponse.message = "OK";
                return reponse;
            }
            catch(Exception ex)
            {
                var er = ex.Message;
                reponse.error.Add(er);
                return reponse;
            }          
        }

        public async Task DeleteWidgetAsync(string id)
        {
            await _widgetRepository.DeleteAsync(id);
        }
    }
}
