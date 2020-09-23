using System;
using System.Collections.Generic;

namespace ERP.Model.Models
{
    public partial class EmployeeRelative
    {
        public long Id { get; set; }
        public string CreateUser { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool? Deleted { get; set; }
        public string Note { get; set; }
        public string EmployeeCode { get; set; }
        public string RelativeType { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string OriginAddress { get; set; }
        public string Job { get; set; }
        public string Phone { get; set; }
    }
}
