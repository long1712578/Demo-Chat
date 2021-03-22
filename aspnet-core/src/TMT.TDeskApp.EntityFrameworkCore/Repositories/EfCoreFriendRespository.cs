using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMT.TDeskApp.EntityFrameworkCore;
using TMT.TDeskApp.Friends;
using TMT.TDeskApp.Objects;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace TMT.TDeskApp.Repositories
{
    public class EfCoreFriendRespository : EfCoreRepository<TDeskAppDbContext, Friend, string>, IFriendRespository
    {
        public EfCoreFriendRespository(
           IDbContextProvider<TDeskAppDbContext> dbContextProvider)
           : base(dbContextProvider)
        {
        }
        public async Task<ObjectResponse> GetFriends(string id)
        {
            ObjectResponse ob = new ObjectResponse();
            try
            {
                List<string> listFId = DbContext.Friends.Where(x => x.UserRecive == id && x.SendDate != null && x.CancleDate == null && x.AcceptDate != null).Select(u => u.UserSend).ToList();
                List<string> listNameFriend = DbContext.Users.Where(x => listFId.Contains(x.Id)).Select(n => n.UserName).ToList();
                ob.data = listNameFriend;
                ob.message = "lay thanh cong";
                return ob;

            }
            catch(Exception ex)
            {
                ob.error = new List<object>();
                ob.error.Add(ex.Message);
                ob.message = "error access";
                return ob;
            }        
            
        }
    }
}
