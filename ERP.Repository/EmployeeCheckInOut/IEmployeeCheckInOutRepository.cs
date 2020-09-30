using ERP.Model.DataTransferObjects;
using ERP.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Repository
{
    public interface IEmployeeCheckInOutRepository : IRepository<EmployeeCheckInOut>
    {
        public List<TimeRangDataTransfer> GetTimeRangeDataTransfer(DateTime? FromDate, DateTime? ToDate);
    }
}
