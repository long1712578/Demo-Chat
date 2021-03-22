using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TMT.Auditing;

namespace TMT.TDeskApp.Messages
{
    public class CreateMessageDto
    { 
        [Required]
        public string Content { get; set; }

        public string Type { get; set; }
        public string Status { get; set; }

        [Required]
        public string SenderName { get; set; }
        public string ReceiverName { get; set; }
        public string ConversationId { get; set; }
    }
}
