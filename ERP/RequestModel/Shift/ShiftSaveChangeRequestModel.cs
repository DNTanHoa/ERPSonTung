using System;
using System.ComponentModel.DataAnnotations;

namespace ERP.RequestModel.Shift
{
    public class ShiftSaveChangeRequestModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Mã ca làm việc không được để trống")]
        public string Code { get; set; }
        public string Name { get; set; }
        public TimeSpan? WorkStartTime { get; set; }
        public TimeSpan? WorkEndTime { get; set; }
        public TimeSpan? RestStatTime { get; set; }
        public TimeSpan? RestEndTime { get; set; }
    }
}
