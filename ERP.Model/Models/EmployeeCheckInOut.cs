using System;
using System.Collections.Generic;

namespace ERP.Model.Models
{
    /// <summary>
    /// Check in, Check out của nhân viên
    /// </summary>
    public partial class EmployeeCheckInOut : BaseModel
    {
        public string EmployeeCode { get; set; }    //Mã nhân viên
        public DateTime? CheckTime { get; set; }    //thời gian checkin/Out
        public string CheckWay { get; set; }        //Phương thức check: Máy chấm công, check trực tiếp
        public string CheckTypeCode { get; set; }   //Bổ sung, trực tiếp
    }
}
