using System;
using System.Collections.Generic;

namespace ERP.Model.Models
{
    /// <summary>
    /// Lưu thời gian hoạt động của nhân viên: Vào công ty, chuyển bộ phận, nghỉ việc...
    /// </summary>
    public partial class EmployeeHistory : BaseModel
    {
        public string EmployeeCode { get; set; }        //Mã nhân viên
        public string ChangeType { get; set; }          //Loại hoạt động
        public string SourceCode { get; set; }          //Từ phòng ban/bộ phận nào
        public string DestinationCode { get; set; }     //Chuyển tới phòng ban/bộ phận nào
        public DateTime? ChangeDate { get; set; }       //Ngày chuyển, ngày và công ty, ngày nghỉ việc
    }
}
