using System.Collections.Generic;
using System.Threading.Tasks;
using TMT.TDeskApp.Messages;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace TMT.TDeskApp.EntityFrameworkCore.Messages
{
    public class EfCoreMessageRespository : EfCoreRepository<TDeskAppDbContext, Message, string>, IMessageRespository
    {
    
        public EfCoreMessageRespository(
           IDbContextProvider<TDeskAppDbContext> dbContextProvider)
           : base(dbContextProvider)
        {
        }
        public async Task<List<Message>> GetAll()
        {
            return await GetListAsync();
            
        }

        [System.Obsolete]
        public void SaveChange()
        {
            DbContext.SaveChanges();

        }

        public async Task SaveChangeAsync()
        {
            await DbContext.SaveChangesAsync();
        }

        public async Task Update(string content,string id)
        {
            var message = await DbContext.Messages.FindAsync(id);
            message.Content = content;
            DbContext.SaveChanges();
        }
    }
}
