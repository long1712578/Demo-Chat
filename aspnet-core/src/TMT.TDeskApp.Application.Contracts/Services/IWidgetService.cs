using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TMT.TDeskApp.Objects;
using TMT.TDeskApp.Widgets;

namespace TMT.TDeskApp.Services
{
    public interface IWidgetService
    {
        Task<List<WidgetDto>> GetAllWidget();
        Task<ObjectResponse> CreateWidgetAsync(CreateWidgetDto input);
        Task<ObjectResponse> UpdateWidgetAsync(string id, UpdateWidgetDto input);
        Task DeleteWidgetAsync(string id);


    }
}
