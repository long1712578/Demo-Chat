using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TMT.TDeskApp.Conversations;
using TMT.TDeskApp.Messages;
using TMT.TenantManagement;
using TMT.UniqueKey;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace TMT.TDeskApp.Domain
{
    public class TMTDataSeedContributor : ITMTDataSeedContributor, ITransientDependency
    {
        private IConversationRespository _conversationRepository;
        private IMessageRespository _messageRepository;

        public TMTDataSeedContributor(IConversationRespository conversationRepository,
            IMessageRespository messageRepository)
        {
            _conversationRepository = conversationRepository;
            _messageRepository = messageRepository;
        }

        public virtual Task SeedAsync(TMTTenantDataSeedContext context)
        {
            // TODO: Khởi tạo dữ liệu mẫu
            //return InitMessages();
            return Task.CompletedTask;
        }

        public Task SeedAsync(DataSeedContext context)
        {
            return Task.CompletedTask;
        }

        private async Task InitMessages()
        {
            //var result = await _conversationRepository.InsertAsync(new Conversation
            //{
            //});

            //await _messageRepository.InsertAsync(new Message
            //{
            //    ConversationId = result.Id,
            //    Content = "test"
            //});

            return;
        }
    }
}
