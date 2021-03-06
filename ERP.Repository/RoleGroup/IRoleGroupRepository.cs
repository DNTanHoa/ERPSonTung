﻿using ERP.Model.DataTransferObjects;
using ERP.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Repository
{
    public interface IRoleGroupRepository : IRepository<RoleGroup>
    {
        public bool IsExistCode(string Code);
    }
}
