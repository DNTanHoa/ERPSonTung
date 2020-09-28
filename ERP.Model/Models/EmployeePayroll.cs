using System;
using System.Collections.Generic;

namespace ERP.Model.Models
{
    public partial class EmployeePayroll : BaseModel
    {
        public string PayrollType { get; set; }
        public decimal? Amount { get; set; }
        public string PayWayCode { get; set; }
        public string EmployeeCode { get; set; }
    }
}
