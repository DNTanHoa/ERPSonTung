using ERP.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Model.DataTransferObjects
{
    public class RecruitmentPlanDataTransfer : RecruitmentPlan
    {
        public string Department { get; set; }
        public string Job { get; set; }
        public string DisplayStatus { get; set; }
    }
}
