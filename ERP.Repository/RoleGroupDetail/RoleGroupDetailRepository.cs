﻿using ERP.Model.DataTransferObjects;
using ERP.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Repository
{
    public class RoleGroupDetailRepository : Repository<RoleGroupDetail>, IRoleGroupDetailRepository
    {
        public RoleGroupDetailRepository(SonTungContext context) : base(context)
        {
            this.context = context;
        }

        public List<RoleGroupDetail> GetByRoleGroupCode(string RoleGroupCode)
        {
            return context.RoleGroupDetail.Where(item => item.RoleGroupCode.Equals(RoleGroupCode)).ToList();
        }
    }
}
