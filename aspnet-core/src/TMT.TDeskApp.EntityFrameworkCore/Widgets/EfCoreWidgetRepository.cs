using System.Collections.Generic;
using System.Threading.Tasks;
using TMT.TDeskApp.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using System;
namespace TMT.TDeskApp.Widgets
{
    public class EfCoreWidgetRepository : EfCoreRepository<TDeskAppDbContext, Widget, string>, IWidgetRepository
    {

        public EfCoreWidgetRepository(
           IDbContextProvider<TDeskAppDbContext> dbContextProvider)
           : base(dbContextProvider)
        {
        }
        public async Task<List<Widget>> GetAll()
        {
            return await GetListAsync();

        }
      
        public async Task SaveChange()
        {
             DbContext.SaveChanges();

        }
    }
}
