using System;
using System.Collections.Generic;
using System.Text;

namespace TMT.TDeskApp.Messages
{
    public  class MessageEto
    {
        public string Content { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string SenderName { get; set; }
        public string ReveiverName { get; set; }
        public string ConversationId { get; set; }
        public DateTime UpdateAt { get; set; }
        public List<string> ListUserId { get; set; }
    }
}
