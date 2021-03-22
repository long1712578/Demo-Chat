using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMT.Auditing;

namespace TMT.TDeskApp.CannedResponses
{
    public class CannedResponse: TMTFullAuditedAggregateRoot<string>
    {
        public string Title { get; set; }
        public string Text { get; set; }
    }
}
