using System;
using System.Collections.Generic;

namespace ERP.Model.Models
{
    /// <summary>
    /// Trả lương
    /// </summary>
    public partial class EmployeePayroll : BaseModel
    {
        public string PayrollType { get; set; }     //Chi phụ cấp, chi thưởng, ứng lương
        public decimal? Amount { get; set; }        //Số tiền
        public string PayWayCode { get; set; }      //Loại: Chuyển khoản, tiền mặt, bên thứ 3...
        public string EmployeeCode { get; set; }    //Mã nhân viên
    }
}
