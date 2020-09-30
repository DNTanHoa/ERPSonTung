using ERP.Model.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.MVC.Models
{
    public class EmployeeTimeKeepingTableModel
    {
        public List<TimeRangDataTransfer> DateInRanges { get; set; }
    }
}
