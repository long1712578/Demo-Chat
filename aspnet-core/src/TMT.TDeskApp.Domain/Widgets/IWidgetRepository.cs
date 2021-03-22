using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace TMT.TDeskApp.Widgets
{
    public interface IWidgetRepository : IRepository<Widget, string>
    {
        Task<List<Widget>> GetAll();
         Task SaveChange();
    }
}
