using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TMT.TDeskApp.Messages;
using TMT.TDeskApp.Objects;

namespace TMT.TDeskApp.Services
{
    public interface IMessageService
    {
        Task<List<MessageDto>> GetAll();
        Task<ObjectResponse> CreateMessageAsync(CreateMessageDto input);
        Task UpdateMessage(string id, UpdateMessageDto input);
        Task DeleteMessage(string id);
    }
}
