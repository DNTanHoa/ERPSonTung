using ERP.Model.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace ERP.Repository
{
    public class EntityCenterRepository : Repository<EntityCenter>, IEntityCenterRepository
    {
        public EntityCenterRepository(SonTungContext context): base(context) { }

        public string GetCodeByEntity(string Entity)
        {
            var entity = context.EntityCenter.Where(item => item.Entity.Equals(Entity)).FirstOrDefault();
            if(entity != null)
            {
                bool parse = int.TryParse(entity.NumberCount, out int result);
                if (parse)
                {
                    var code = entity.PrefixCode + (result + 1).ToString().PadLeft(entity.NumberCount.Length, '0');
                    entity.NumberCount = (result + 1).ToString().PadLeft(entity.NumberCount.Length, '0');
                    return code;
                }
                return null;
            }
            return null;
        }
    }
}
