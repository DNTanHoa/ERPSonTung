using System;
using System.Collections.Generic;

namespace ERP.Model.Models
{
    public partial class TrainingCourseEmployee
    {
        public long Id { get; set; }
        public string CreateUser { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool? Deleted { get; set; }
        public string Note { get; set; }
        public string TrainingCourseCode { get; set; }
        public string EmployeeCode { get; set; }
        public string ResultType { get; set; }
        public string Point { get; set; }
    }
}
