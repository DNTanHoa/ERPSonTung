﻿using ERP.Model.DataTransferObjects;
using ERP.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Repository
{
    public class ShiftEmployeeRepository : Repository<ShiftEmployee>, IShiftEmployeeRepository
    {
        public ShiftEmployeeRepository(SonTungContext context) : base(context)
        {
            this.context = context;
        }

        
    }
}
