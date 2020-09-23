using ERP.Model.DataTransferObjects;
using ERP.Model.Models;
using ERP.Ultilities.Extensions;
using ERP.Ultilities.Global;
using ERP.Ultilities.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace ERP.Repository
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(SonTungContext context) : base(context)
        {
            this.context = context;
        }

        public IEnumerable<EmployeeDataTransfer> GetDataTransfer()
        {
            DataTable table = SqlHelper.Fill(AppGlobal.ConnectionString, "sprocEmployeeSelectAll");
            return table.ToList<EmployeeDataTransfer>();
        }
    }
}
