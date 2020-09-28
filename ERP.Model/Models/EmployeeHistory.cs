using System;
using System.Collections.Generic;

namespace ERP.Model.Models
{
    public partial class EmployeeHistory : BaseModel
    {
        public string EmployeeCode { get; set; }
        public string ChangeType { get; set; }
        public string SourceCode { get; set; }
        public string DestinationCode { get; set; }
        public DateTime? ChangeDate { get; set; }
    }
}
