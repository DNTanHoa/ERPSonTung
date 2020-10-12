using System;
using System.Collections.Generic;

namespace ERP.Model.Models
{
    public partial class Navigation : BaseModel
    {
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string Type { get; set; }
        public string Icon { get; set; }
        public string DisplayName { get; set; }
        public string ParentCode { get; set; }
        public string Code { get; set; }
        public long? SortOrder { get; set; }
        public string ComponentPath { get; set; }
        public string ComponentName { get; set; }
    }
}
