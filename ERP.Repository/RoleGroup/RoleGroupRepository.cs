using ERP.Model.DataTransferObjects;
using ERP.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Repository
{
    public class RoleGroupRepository : Repository<RoleGroup>, IRoleGroupRepository
    {
        public RoleGroupRepository(SonTungContext context) : base(context)
        {
            this.context = context;
        }

        public bool IsExistCode(string Code)
        {
            var roleGroup = context.RoleGroup.Where(item => item.Code.Equals(Code)).FirstOrDefault();
            return roleGroup != null ? true : false;
        }
    }
}
