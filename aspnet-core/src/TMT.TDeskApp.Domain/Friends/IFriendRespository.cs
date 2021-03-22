using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMT.TDeskApp.Objects;
using Volo.Abp.Domain.Repositories;

namespace TMT.TDeskApp.Friends
{
    public interface IFriendRespository : IRepository<Friend, string>
    {
        Task<ObjectResponse> GetFriends(string id);
    }
}
