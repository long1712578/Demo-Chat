using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TMT.TDeskApp.Messages
{
    public class UpdateMessageDto
    {
        [Required]
        public string Content { get; set; }
    }
}
