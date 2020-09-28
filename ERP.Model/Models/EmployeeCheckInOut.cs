using System;
using System.Collections.Generic;

namespace ERP.Model.Models
{
    public partial class EmployeeCheckInOut : BaseModel
    {
        public string EmployeeCode { get; set; }
        public DateTime? CheckTime { get; set; }
        public string CheckWay { get; set; }
    }
}
