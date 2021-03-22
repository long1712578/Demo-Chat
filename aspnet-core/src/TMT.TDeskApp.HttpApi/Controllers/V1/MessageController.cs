using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMT.TDeskApp.Messages;
using TMT.TDeskApp.Objects;
using TMT.TDeskApp.Services;
using Volo.Abp.AspNetCore.Mvc;

namespace TMT.TDeskApp.Controllers.V1
{
   [Route("api/v1/messages")]
  public class MessageController: AbpController
    {
        private readonly IMessageService _service;
        private readonly IKafkaService _evenBusKafka;
        private readonly IUserConversationService _userConversationService;

        public MessageController(IMessageService service, IKafkaService evenBusKafka, IUserConversationService userConversationService)
        {
            _service = service;
            _evenBusKafka = evenBusKafka;
            _userConversationService = userConversationService;
        }

        [HttpGet]
        public async Task<List<MessageDto>> GetListMessage()            
        {
            return await _service.GetAll();
        }

        [HttpPost]
        public async Task<ActionResult<object>> CreateMessage([FromBody]CreateMessageDto input)
        {
            ObjectResponse response = new ObjectResponse();
            
            response = await _service.CreateMessageAsync(input);
            response.data = null;

            if (response.error.Count<1||response.error==null)
            {
                var messageEto = new MessageEto
                {
                    Content = input.Content,
                    Type = input.Type,
                    Status = input.Status,
                    SenderName = input.SenderName,
                    ReveiverName = input.ReceiverName,
                    ConversationId = input.ConversationId,
                    UpdateAt = DateTime.Now,
                    ListUserId = await _userConversationService.GetListUserId(input.ConversationId)
                };
                await _evenBusKafka.CreateAsync(messageEto);
                return Ok(response);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateMessage(string id, [FromBody] UpdateMessageDto input)
        {
            await _service.UpdateMessage(id, input);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteMessage(string id)
        {
            await _service.DeleteMessage(id);
            return Ok();
        }
    }
}
