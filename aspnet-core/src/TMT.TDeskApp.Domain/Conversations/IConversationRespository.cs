using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace TMT.TDeskApp.Conversations
{
    public interface IConversationRespository : IRepository<Conversation, string>
    {
        Task<List<Conversation>> GetAll();
    }
}
