using ERP.Model.DataTransferObjects;
using ERP.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Repository
{
    public interface IShiftRepository : IRepository<Shift>
    {
        public bool IsExistCode(string Code);
    }
}
