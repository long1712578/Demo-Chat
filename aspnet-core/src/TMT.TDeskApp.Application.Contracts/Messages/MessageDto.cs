using System;
using System.Collections.Generic;
using System.Text;
using TMT.Auditing;
using TMT.TenantManagement;

namespace TMT.TDeskApp.Messages
{
    public class MessageDto
    {
        public string Content { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
        public string SenderName { get; set; }
        public string ReceiverName { get; set; }
        public string ConversationId { get; set; }

    }
}
