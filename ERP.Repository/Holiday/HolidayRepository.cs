using ERP.Model.DataTransferObjects;
using ERP.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Repository
{
    public class HolidayRepository : Repository<Holiday>, IHolidayRepository
    {
        public HolidayRepository(SonTungContext context) : base(context)
        {
            this.context = context;
        }

        public bool IsExistCode(string Code)
        {
            var holiday = context.Holiday.Where(item => item.Code.Equals(Code)).FirstOrDefault();
            return holiday != null ? true : false;
        }
    }
}
