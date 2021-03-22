using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMT.Auditing;

namespace TMT.TDeskApp.WidgetUsers
{
    public class WidgetUser: TMTFullAuditedAggregateRoot<string>
    {
        public string Role { get; set; }
        public string WidgetId { get; set; }
    }
}
