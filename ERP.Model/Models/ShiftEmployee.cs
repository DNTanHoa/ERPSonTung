using System;
using System.Collections.Generic;

namespace ERP.Model.Models
{
    public partial class ShiftEmployee : BaseModel
    {
        public string ShiftCode { get; set; }
        public string EmployeeCode { get; set; }
    }
}
