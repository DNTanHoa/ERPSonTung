using System;
using System.Collections.Generic;

namespace ERP.Model.Models
{
    public partial class EmployeeDocument : BaseModel
    {
        public string DocumentType { get; set; }
        public string Path { get; set; }
        public string NumberCode { get; set; }
        public string EmployeeCode { get; set; }
    }
}
