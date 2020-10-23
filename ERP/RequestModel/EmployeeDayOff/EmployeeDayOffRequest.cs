using ERP.Model.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace ERP.RequestModel.Employee
{
    public class EmployeeDayOffRequest : BaseModel
    {
        public string EmployeeCode { get; set; }

        public DateTime FromTime { get; set; }

        public DateTime ToTime { get; set; }

        public string Reason { get; set; }

        public string ApproveStatus { get; set; }
    }
}