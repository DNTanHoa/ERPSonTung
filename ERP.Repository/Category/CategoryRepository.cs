using ERP.Model.Models;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(SonTungContext context) : base(context) { }

        public IEnumerable<Category> GetByEntity(string Entity)
        {
            return context.Category.Where(item => item.Entity.Equals(Entity) &&
                                          item.Deleted == false);
        }
    }
}
