using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TMT.TDeskApp.Services
{
    public interface IUserConversationService
    {
        Task<List<string>> GetListUserId(string id);
    }
}
