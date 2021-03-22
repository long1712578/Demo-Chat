using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace TMT.TDeskApp.Messages
{
    public class MessageManager : DomainService
    {
        private readonly IMessageRespository _messageRespository;

        public MessageManager(IMessageRespository messageRespository)
        {
            _messageRespository = messageRespository;
        }
        public async Task CreateMessage(string content, string type, string status, string senderName, string receiverName, string conversationId)
        {
            var entity = new Message(content, type, status, senderName, receiverName, conversationId);

            await _messageRespository.InsertAsync(entity);
            await _messageRespository.SaveChangeAsync();
        }
        public async Task DeleteMessage(string id)
        {
            await _messageRespository.DeleteAsync(id);
        }
    }
}
