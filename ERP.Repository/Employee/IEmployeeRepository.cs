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
    }
}
