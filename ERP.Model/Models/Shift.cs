using System;
using System.Collections.Generic;

namespace ERP.Model.Models
{
    /// <summary>
    /// Ca làm việc
    /// </summary>
    public partial class Shift : BaseModel
    {
        public string Code { get; set; }                //Mã ca làm việc
        public string Name { get; set; }                //Tên ca làm việc
        public TimeSpan? WorkStartTime { get; set; }    //Thời gian bắt đầu
        public TimeSpan? WorkEndTime { get; set; }      //Thời gian kết thúc
        public TimeSpan? RestStatTime { get; set; }     //Thời gian bắt đầu nghỉ giải lao
        public TimeSpan? RestEndTime { get; set; }      //Thời gian kết thúc giải lao
    }
}
