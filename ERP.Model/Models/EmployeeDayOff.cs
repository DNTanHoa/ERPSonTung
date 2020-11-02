using System;
using System.Collections.Generic;

namespace ERP.Model.Models
{
    /// <summary>
    /// Ngày nghỉ
    /// </summary>
    public partial class EmployeeDayOff : BaseModel
    {
        public string EmployeeCode { get; set; }    //Mã nhân viên
        public DateTime? FromTime { get; set; }     //Từ thời gian
        public DateTime? ToTime { get; set; }       //Đến thời gian
        public string Reason { get; set; }          //Lý do
        public string ApproveStatus { get; set; }   //Trạng thái phê duyệt nghỉ
    }
}
