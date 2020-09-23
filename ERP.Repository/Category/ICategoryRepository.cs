using ERP.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Repository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        public IEnumerable<Category> GetByEntity(string Entity);
    }
}
