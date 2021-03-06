﻿using ERP.Model.DataTransferObjects;
using ERP.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Repository
{
    public interface ICheckInOutDeviceRepository : IRepository<CheckInOutDevice>
    {
        public bool IsExistCode(string Code);
    }
}
