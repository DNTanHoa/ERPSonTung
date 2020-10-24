using System;
using System.Collections.Generic;

namespace ERP.RequestModel
{
    public class TrainingCourseSaveChangeRequestModel
    {
        public long Id { get; set; }
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
