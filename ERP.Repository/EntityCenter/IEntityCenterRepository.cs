using ERP.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Repository
{
    public interface IEntityCenterRepository : IRepository<EntityCenter>
    {
        public string GetCodeByEntity(string Entity);
    }
}
