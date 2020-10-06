using ERP.Model.Models;
using System;

namespace ERP.RequestModel.Employee
{
    public class EmployeeFilterRequestModel : BaseModel
    {
        public string DepartmentCode { get; set; }

        public string GroupCode { get; set; }

        public string LaborGroupCode { get; set; }

        public string StatusCode { get; set; }

        public DateTime? StartFromDate { get; set; }

        public DateTime? StartToDate { get; set; }
    }
}
