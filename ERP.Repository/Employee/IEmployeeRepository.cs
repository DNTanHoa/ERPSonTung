using ERP.Model.DataTransferObjects;
using ERP.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ERP.Repository
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        public IEnumerable<EmployeeDataTransfer> GetDataTransfer();

        public IEnumerable<EmployeeModelTemplate> GetModelTemplates();

        public IEnumerable<EmployeeDataTransfer> GetDataTransferHasFilter(string DepartmentCode, string GroupCode, string LaborGroupCode, string StatusCode, DateTime? StartFromDate, DateTime? StartToDate);

        public bool IsExistCode(string Code);

        public IEnumerable<Employee> GetEmployeeHasBirthdayInTimeRange(DateTime FromDate, DateTime ToDate);

        public IEnumerable<Employee> GetEmployeeHasContractExpireInTimeRange(DateTime FromDate, DateTime ToDate);
    }
}
