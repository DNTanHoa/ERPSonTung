using ERP.Model.DataTransferObjects.EmployeeDayOff;
using ERP.Model.Models;
using System.Collections.Generic;

namespace ERP.Repository
{
    public interface IEmployeeRelativeRepository : IRepository<EmployeeRelative>
    {
        public List<EmployeeRelativeDataTransfer> GetFilteredItems(string employeeCode);

        public EmployeeRelative GetItemById(long id);

        public List<EmployeeRelative> GetItemsByEmployeeCode(string employeeCode);

    }
}