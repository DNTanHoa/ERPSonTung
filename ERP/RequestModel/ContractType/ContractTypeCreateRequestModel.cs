using System;
using System.Collections.Generic;

namespace ERP.RequestModel
{
    public class ContractTypeCreateRequestModel
    {
        public string Code { get; set; }
        public string TextName { get; set; }
        public decimal? SalaryPercent { get; set; }
        public int? NumberOfDate { get; set; }
        public int? AnnualLeave { get; set; }
        public string TemplatePath { get; set; }
    }
}
