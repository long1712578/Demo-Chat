using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMT.TDeskApp.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace TMT.TDeskApp.UserConversations
{
    public class EfCoreUserConversationRepository : EfCoreRepository<TDeskAppDbContext, UserConversation, string>, IUserConversationRepository
    {
        public EfCoreUserConversationRepository(
           IDbContextProvider<TDeskAppDbContext> dbContextProvider)
           : base(dbContextProvider)
        {
        }

        [Obsolete]
        public async Task<List<string>> GetListUserId(string id)
        {
            return DbSet.Where(x => x.ConversationId == id).Select(x => x.Id).ToList();
        }
    }
}
