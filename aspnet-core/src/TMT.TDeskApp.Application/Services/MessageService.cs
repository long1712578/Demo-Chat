
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMT.TDeskApp.Messages;
using TMT.TDeskApp.Objects;
using Volo.Abp;
using Volo.Abp.Application.Services;

namespace TMT.TDeskApp.Services
{

    [RemoteService(IsEnabled = false)]
    public class MessageService : ApplicationService, IMessageService
    {

        private readonly IMessageRespository _messagerespository;
        private readonly MessageManager _messageManager;
        public MessageService(IMessageRespository messagerespository, MessageManager messageManager)
        {
            _messagerespository = messagerespository;
            _messageManager = messageManager;
        }
        
        public async Task<List<MessageDto>> GetAll()
        {
            List<Message> lstMs = await _messagerespository.GetAll();
            return ObjectMapper.Map<List<Message>, List<MessageDto>>(lstMs);
        }

        public async Task<ObjectResponse> CreateMessageAsync(CreateMessageDto input)
        {
            ObjectResponse reponse = new ObjectResponse();
            try
            {
               await _messageManager.CreateMessage(
               input.Content,
               input.Type,
               input.Status,    
               input.SenderName,
               input.ReceiverName,
               input.ConversationId
               );
                
                reponse.message = "Ok";
                return reponse;
            }
            catch(Exception ex)
            {
                var er = ex.Message;
                reponse.error.Add(er);
                return reponse;
            }
        }

        public async Task UpdateMessage(string id, UpdateMessageDto input)
        {
            await _messagerespository.Update(input.Content, id);            
        }

        public async Task DeleteMessage(string id)
        {
            await _messageManager.DeleteMessage(id);
        }
    }
}
