using System;
using System.Collections.Generic;

namespace ERP.Model.Models
{
    public partial class EmployeeContract : BaseModel
    {
        public string ContractType { get; set; }
        public DateTime? SignDate { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public decimal? Salary { get; set; }
        public string CompanySignPerson { get; set; }
        public string EmployeeSignPerson { get; set; }
        public string MainContent { get; set; }
        public string Path { get; set; }
        public string NumberCode { get; set; }
        public string ParentCode { get; set; }
    }
}
