using ERP.Model.DataTransferObjects.EmployeeDayOff;
using ERP.Model.Models;
using System;
using System.Collections.Generic;

namespace ERP.Repository
{
    public interface IEmployeeDayOffRepository : IRepository<EmployeeDayOff>
    {
        public List<EmployeDayOffDataTransfer> GetItems(string employeeCode, DateTime? fromDate, DateTime? toDate);
    }
}