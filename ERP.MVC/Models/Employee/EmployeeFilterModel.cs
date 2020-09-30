using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.MVC.Models.Employee
{
    public class EmployeeFilterModel
    {
        public string DepartmentCode { get; set; }

        public string GroupCode { get; set; }

        public string LaborGroupCode { get; set; }

        public string StatusCode { get; set; }

        public DateTime? StartFromDate { get; set; }

        public DateTime? StartToDate { get; set; }
    }
}
