using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMT.TDeskApp.UserConversations;
using Volo.Abp;
using Volo.Abp.Application.Services;

namespace TMT.TDeskApp.Services
{
    [RemoteService(IsEnabled = false)]
    public class UserConversationService : ApplicationService, IUserConversationService
    {
        private readonly IUserConversationRepository _userConversationRespository;
        public UserConversationService(IUserConversationRepository userConversations)
        {
            _userConversationRespository = userConversations;
        }
        public async Task<List<string>> GetListUserId(string id)
        {
            return await _userConversationRespository.GetListUserId(id);
        }
    }
}
