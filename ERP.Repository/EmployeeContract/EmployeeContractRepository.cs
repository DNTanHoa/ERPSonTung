using ERP.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Repository
{
    public class EmployeeContractRepository : Repository<EmployeeContract>, IEmployeeContractRepository
    {
        public EmployeeContractRepository(SonTungContext context) : base(context)
        {
            this.context = context;
        }

    }
}
