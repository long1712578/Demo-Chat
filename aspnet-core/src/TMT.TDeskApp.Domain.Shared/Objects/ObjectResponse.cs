using System;
using System.Collections.Generic;
using System.Text;

namespace TMT.TDeskApp.Objects
{
    public class ObjectResponse 
    {
        public object data { get; set; }
        public List<object> error { get; set; } = new List<object>();
        public string message { get; set; }
    }
}
