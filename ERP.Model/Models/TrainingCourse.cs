using System;
using System.Collections.Generic;

namespace ERP.Model.Models
{
    public partial class TrainingCourse
    {
        public long Id { get; set; }
        public string CreateUser { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool? Deleted { get; set; }
        public string Note { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public decimal? PlannedCost { get; set; }
        public decimal? RealCost { get; set; }
        public string ParentCode { get; set; }
    }
}
