using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Model.DataTransferObjects
{
    public class DashboardOverviewDataTransfer
    {
        public int EmployeeCount { get; set; }

        public int EmployeeLeaveWithPermission { get; set; }

        public int EmployeeLeaveNoPermission { get; set; }

        public decimal PercentLeave { get; set; }
    }
}
