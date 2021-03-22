using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMT.TDeskApp.Friends;
using TMT.TDeskApp.Objects;
using Volo.Abp;
using Volo.Abp.Application.Services;

namespace TMT.TDeskApp.Services
{
    [RemoteService(IsEnabled = false)]
    public class FriendService : ApplicationService, IFriendService
    {
        private readonly IFriendRespository _friendrespository;
        public FriendService(IFriendRespository friendrespository)
        {
            _friendrespository = friendrespository;
        }
        public async Task<ObjectResponse> GetFriends(string id)
        {
            ObjectResponse ob = new ObjectResponse();
            ob = await _friendrespository.GetFriends(id);
            return ob;
        }
    }
}
