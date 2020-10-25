using ERP.Model.DataTransferObjects;
using ERP.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Repository
{
    public class CheckInOutDeviceRepository : Repository<CheckInOutDevice>, ICheckInOutDeviceRepository
    {
        public CheckInOutDeviceRepository(SonTungContext context) : base(context)
        {
            this.context = context;
        }

        public bool IsExistCode(string Code)
        {
            var checkInOutDevice = context.CheckInOutDevice.Where(item => item.Code.Equals(Code)).FirstOrDefault();
            return checkInOutDevice != null ? true : false;
        }
    }
}
