using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Model.Models
{
    public class EntityCenter : BaseModel
    {
        public string Entity { get; set; }
        public string PrefixCode { get; set; }
        public string NumberCount { get; set; }
    }
}
