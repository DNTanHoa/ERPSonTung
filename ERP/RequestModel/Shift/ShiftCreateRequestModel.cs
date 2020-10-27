using System;
using System.ComponentModel.DataAnnotations;

namespace ERP.RequestModel.Shift
{
    public class ShiftCreateRequestModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public TimeSpan? WorkStartTime { get; set; }
        public TimeSpan? WorkEndTime { get; set; }
        public TimeSpan? RestStatTime { get; set; }
        public TimeSpan? RestEndTime { get; set; }
    }
}
