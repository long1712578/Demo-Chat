using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMT.TDeskApp.Objects;
using TMT.TDeskApp.Services;
using Volo.Abp.AspNetCore.Mvc;

namespace TMT.TDeskApp.Controllers.V1
{
    [Route("api/v1/friend")]
    public class FriendController: AbpController
    {
        private readonly IFriendService _friendService;

        public FriendController(IFriendService friendService)
        {
            _friendService = friendService;
        }
        [HttpGet]
        public async Task<IActionResult> GetListFriend(string id)

        {
            ObjectResponse ob = new ObjectResponse();
            ob = await _friendService.GetFriends(id);
            if(ob.error==null||ob.error.Count()==0)
            {
                return Ok(ob);
            }
            else
            {
                return StatusCode(500, ob);
            }
        }

    }
}
