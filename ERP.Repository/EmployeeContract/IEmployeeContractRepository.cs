using ERP.Model.Models;
using System.Collections.Generic;

namespace ERP.Repository
{
    public interface IEmployeeContractRepository : IRepository<EmployeeContract>
    {

        EmployeeContract GetByCode(string code);

        List<EmployeeContract> GetListByEmployeeCode(string employeeCode);

    }
}