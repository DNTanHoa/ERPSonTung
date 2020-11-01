using System;
using System.Collections.Generic;

namespace ERP.Model.Models
{
    /// <summary>
    /// Tài liệu cá nhân của nhân viên: CMND, Hình...
    /// </summary>
    public partial class EmployeeDocument : BaseModel
    {
        public string DocumentType { get; set; }        //Loại tài liệu
        public string Path { get; set; }                //Đường dẫn đên tài liệu
        public string NumberCode { get; set; }          //Số hồ sơ
        public string EmployeeCode { get; set; }        //Mã nhân viên
    }
}
