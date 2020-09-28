using System;
using System.Collections.Generic;

namespace ERP.Model.Models
{
    public partial class Shift : BaseModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public TimeSpan? WorkStartTime { get; set; }
        public TimeSpan? WorkEndTime { get; set; }
        public TimeSpan? RestStatTime { get; set; }
        public TimeSpan? RestEndTime { get; set; }
    }
}
