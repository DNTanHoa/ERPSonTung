using ERP.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace ERP.Repository
{
    public class EmployeeContractRepository : Repository<EmployeeContract>, IEmployeeContractRepository
    {
        public EmployeeContractRepository(SonTungContext context) : base(context)
        {
            this.context = context;
        }

        public EmployeeContract GetByCode(string code)
        {
            var currentObj = this.context.EmployeeContract.SingleOrDefault(n => n.NumberCode.Equals(code) && n.Deleted == false);
            return currentObj;
        }

        public List<EmployeeContract> GetListByEmployeeCode(string employeeCode)
        {
            var lstObj = this.context.EmployeeContract.Where(n => n.EmployeeSignPerson.Equals(employeeCode) && n.Deleted == false);
            return lstObj.ToList();
        }
    }
}