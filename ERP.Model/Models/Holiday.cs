using System;
using System.Collections.Generic;

namespace ERP.Model.Models
{
    public partial class Holiday : BaseModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public decimal? SalaryIncreasePercent { get; set; }
    }
}
