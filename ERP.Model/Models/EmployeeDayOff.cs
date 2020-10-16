﻿using System;
using System.Collections.Generic;

namespace ERP.Model.Models
{
    public partial class EmployeeDayOff : BaseModel
    {
        public string EmployeeCode { get; set; }
        public DateTime? FromTime { get; set; }
        public DateTime? ToTime { get; set; }
        public string Reason { get; set; }
        public string ApproveStatus { get; set; }
    }
}
