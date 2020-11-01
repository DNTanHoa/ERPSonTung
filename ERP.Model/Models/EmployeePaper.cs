using System;
using System.Collections.Generic;

namespace ERP.Model.Models
{
    /// <summary>
    /// Giấy tờ liên quan công việc của nhân viên: giấy nghỉ phép, giấy công tác...
    /// </summary>
    public partial class EmployeePaper : BaseModel
    {
        public string Code { get; set; }            // Mã giấy tờ
        public string PaperType { get; set; }       //Loại giấy tờ
        public string PaperContent { get; set; }    //Nội dung
    }
}
