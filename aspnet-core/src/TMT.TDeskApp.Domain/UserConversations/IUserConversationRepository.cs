using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace TMT.TDeskApp.UserConversations
{
    public interface IUserConversationRepository: IRepository<UserConversation, string>
    {
        Task<List<string>> GetListUserId(string id);
    }
}
