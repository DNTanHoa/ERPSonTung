using System;
using System.Collections.Generic;

namespace ERP.RequestModel
{
    public class TrainingCourseEmployeeCreateRequestModel
    {
        public string TrainingCourseCode { get; set; }
        public string EmployeeCode { get; set; }
        public string ResultType { get; set; }
        public string Point { get; set; }
    }
}
