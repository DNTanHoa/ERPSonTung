using System;
using System.Collections.Generic;

namespace ERP.Model.Models
{
    public class Category : BaseModel
    {
        public string Entity { get; set; }
        public string Code { get; set; }
        public string SubCode { get; set; }
        public string Name { get; set; }
        public string ParentCode { get; set; }
    }
}
