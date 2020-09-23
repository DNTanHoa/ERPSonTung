using System;
using System.Collections.Generic;

namespace ERP.Model.Models
{
    public partial class RecruitmentPlan
    {
        public long Id { get; set; }
        public string CreateUser { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool? Deleted { get; set; }
        public string Note { get; set; }
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
