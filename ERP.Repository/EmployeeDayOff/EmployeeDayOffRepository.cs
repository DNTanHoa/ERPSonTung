﻿using ERP.Model.DataTransferObjects.EmployeeDayOff;
using ERP.Model.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace ERP.Repository
{
    public class EmployeeDayOffRepository : Repository<EmployeeDayOff>, IEmployeeDayOffRepository
    {
        public EmployeeDayOffRepository(SonTungContext context) : base(context)
        {

        }

        public List<EmployeDayOffDataTransfer> GetItems(string employeeCode, DateTime? fromDate, DateTime? toDate)
        {

            if (fromDate == null)
                fromDate = DateTime.Now;

            if (toDate == null)
                toDate = new DateTime(fromDate.Value.Year, fromDate.Value.Month, 1).AddMonths(1).AddDays(-1);

            var result = from d in this.context.EmployeeDayOff
                         join r in this.context.Category on d.Reason equals r.Code
                         join a in this.context.Category on d.ApproveStatus equals a.Code
                         join e in this.context.Employee on d.EmployeeCode equals e.Code
                         where (string.IsNullOrEmpty(employeeCode) || d.EmployeeCode == employeeCode)
                         && (d.FromTime >= fromDate && d.ToTime <= toDate)
                         select new EmployeDayOffDataTransfer
                         {
                             Code=d.EmployeeCode,
                             Name=e.FullName,
                             FromTime=d.FromTime,
                             ToTime=d.ToTime,
                             ApproveStatus=a.Name,
                             Reason=r.Name
                         };

            return result.ToList();

        }
    }
}