using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TMT.TDeskApp.Objects;

namespace TMT.TDeskApp.Services
{
    public interface IFriendService
    {
        Task<ObjectResponse> GetFriends(string id);
    }
}
