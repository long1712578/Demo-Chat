using System;
using TMT.Auditing;
using TMT.TenantManagement;
using TMT.UniqueKey;

namespace TMT.TDeskApp.Messages
{
    public class Message: TMTAuditedAggregateRoot<string>, ITMTMultiTenant
    {
        public Message(string content, string type, string status, string senderName, string receiverName, string conversationId)
        {
            Content = content;
            Type = type;
            Status = status;
            SenderName = senderName;
            ReceiverName = receiverName;
            ConversationId = conversationId;
            var generator = new SequentialUniqueKeyGenerator();
            this.Id = generator.Create();
        }

        public Message()
        {
            var generator = new SequentialUniqueKeyGenerator();
            this.Id = generator.Create();
        }
        public void SetId(string Id)
        {
            Id = Id;
        }

        public string Content { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
        public string SenderName { get; set; }
        public string ReceiverName { get; set; }
        public string ConversationId { get; set; }
        public string TenantId { get; }
        public override DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = DateTime.Now; } 
    }
}
