using System;
using System.Collections.Generic;

namespace ERP.Model.Models
{
    /// <summary>
    /// Map giữa nhân viên và ca làm việc
    /// </summary>
    public partial class ShiftEmployee : BaseModel
    {
        public string ShiftCode { get; set; }       //Mã ca làm việc
        public string EmployeeCode { get; set; }    //Mã nhân viên
    }
}
