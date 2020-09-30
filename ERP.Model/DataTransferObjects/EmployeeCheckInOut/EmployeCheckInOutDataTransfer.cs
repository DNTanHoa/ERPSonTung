using ERP.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Model.DataTransferObjects
{
    public class EmployeCheckInOutDataTransfer : EmployeeCheckInOut
    {
        public string EmployeeName { get; set; }
    }
}
