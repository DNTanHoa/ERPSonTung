using System;
using System.Collections.Generic;

namespace ERP.Model.Models
{
    public partial class EmployeePaper : BaseModel
    {
        public string Code { get; set; }
        public string PaperType { get; set; }
        public string PaperContent { get; set; }
    }
}
