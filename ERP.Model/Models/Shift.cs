using System;
using System.Collections.Generic;

namespace ERP.Model.Models
{
    public partial class Shift
    {
        public long Id { get; set; }
        public string CreateUser { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool? Deleted { get; set; }
        public string Note { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public TimeSpan? WorkStartTime { get; set; }
        public TimeSpan? WorkEndTime { get; set; }
        public TimeSpan? RestStatTime { get; set; }
        public TimeSpan? RestEndTime { get; set; }
    }
}
