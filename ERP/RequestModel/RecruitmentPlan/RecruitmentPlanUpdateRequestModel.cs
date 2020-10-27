﻿using System;

namespace ERP.RequestModel
{
    public class RecruitmentPlanUpdateRequestModel
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public decimal? Quantity { get; set; }
        public string JobCode { get; set; }
        public string DepartmentCode { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; }
    }
}