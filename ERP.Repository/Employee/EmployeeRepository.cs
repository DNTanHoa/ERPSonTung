using ERP.Model.DataTransferObjects;
using ERP.Model.Models;
using ERP.Ultilities.Extensions;
using ERP.Ultilities.Global;
using ERP.Ultilities.Helpers;
using System.Data.SqlClient;
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

        public IEnumerable<EmployeeDataTransfer> GetDataTransferHasFilter(string DepartmentCode, string GroupCode, string LaborGroupCode, string StatusCode, DateTime? StartFromDate, DateTime? StartToDate)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@DepartmentCode",DepartmentCode),
                new SqlParameter("@GroupCode",GroupCode),
                new SqlParameter("@LaborGroupCode",LaborGroupCode),
                new SqlParameter("@StatusCode",StatusCode),
                new SqlParameter("@StartToDate", StartToDate),
                new SqlParameter("@StartFromDate", StartFromDate)
            };
            DataTable table = SqlHelper.FillByReader(AppGlobal.ConnectionString, "sprocEmployeeSelectHasFilter", parameters);
            return table.ToList<EmployeeDataTransfer>();
        }

        public IEnumerable<Employee> GetEmployeeHasBirthdayInTimeRange(DateTime FromDate, DateTime ToDate)
        {
            ///TODO: Lấy thông tin nhân viên có ngày sinh theo khoảng thời gian

            var items = this.context.Employee.Where(n => n.DateOfBirth.Value.Month >= FromDate.Month && n.DateOfBirth.Value.Month <= ToDate.Month);

            return items;


        }

        public IEnumerable<Employee> GetEmployeeHasContractExpireInTimeRange(DateTime FromDate, DateTime ToDate)
        {
            ///TODO: Lấy thông tin nhân viên có hợp đồng sắp hết hạn trong khoảng thời gian
            throw new NotImplementedException();
        }

        public IEnumerable<EmployeeModelTemplate> GetModelTemplates()
        {
            var query = from employee in context.Employee
                        select new EmployeeModelTemplate
                        {
                            Code = employee.Code,
                            Display = employee.Code + " - " + employee.FullName
                        };
            return query.ToList();
        }

        public bool IsExistCode(string Code)
        {
            var employee = context.Employee.Where(item => item.Code.Equals(Code)).FirstOrDefault();
            return employee != null ? true : false;
        }

        public List<EmployeeImportDataTransfer> ImportDataTableToList(DataTable table)
        {
            List<EmployeeImportDataTransfer> entities = new List<EmployeeImportDataTransfer>();

            //loop all row in table
            foreach (DataRow row in table.Rows)
            {
                //new instance of T
                Type temp = typeof(EmployeeImportDataTransfer);
                EmployeeImportDataTransfer entity = new EmployeeImportDataTransfer();

                //loop all column in table
                foreach (DataColumn column in table.Columns)
                {
                    //loop all property in T class
                    foreach (PropertyInfo pro in temp.GetProperties())
                    {
                        // T property equal with table's column name
                        // And value of cell not null
                        if (pro.Name == column.ColumnName
                            && row[column.ColumnName] != DBNull.Value)
                        {
                            try
                            {
                                Type t = Nullable.GetUnderlyingType(pro.PropertyType) ?? pro.PropertyType;
                                pro.SetValue(entity, Convert.ChangeType(row[column.ColumnName], t), null);
                                continue;
                            }
                            catch (Exception ex)
                            {
                                entity.IsError = true;
                                entity.ErrorMessage.Add(ex.Message);
                            }
                        }
                    }
                }

                //add entity to list
                entities.Add(entity);
            }

            return entities;
        }
    }
}
