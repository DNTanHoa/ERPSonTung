using ERP.Model.DataTransferObjects.EmployeeDayOff;
using ERP.Model.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace ERP.Repository
{
    public class EmployeeRelativeRepository : Repository<EmployeeRelative>, IEmployeeRelativeRepository
    {

        #region constructor

        public EmployeeRelativeRepository(SonTungContext context) : base(context)
        {
        }

        #endregion

        #region  public method

        public List<EmployeeRelativeDataTransfer> GetFilteredItems(string employeeCode)
        {
            var result = from d in this.context.EmployeeRelative
                         join r in this.context.Category on d.RelativeType equals r.Code
                         join a in this.context.Category on d.OriginProvinceCode equals a.Code
                         where (string.IsNullOrEmpty(employeeCode) || d.EmployeeCode == employeeCode)
                         && d.Deleted == false
                         select new EmployeeRelativeDataTransfer
                         {
                             Name = d.Name,
                             RelationName = r.Name,
                             YearOfBirth = d.DateOfBirth.Value.Year.ToString(),
                             Job = d.Job,
                             Address = d.OriginAddress + " - " + a.Name,
                             Phone = d.Phone
                         };

            return result.ToList();
        }

        public EmployeeRelative GetItemById(long id)
        {
            var item = this.context.EmployeeRelative.AsNoTracking().SingleOrDefault(n => n.Id == id);
            return item;
        }

        public List<EmployeeRelative> GetItemsByEmployeeCode(string employeeCode)
        {
            var item = this.context.EmployeeRelative.Where(n => n.EmployeeCode.Equals(employeeCode));
            return item.ToList();
        }



        #endregion
    }
}