using ERP.Model.DataTransferObjects;
using ERP.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Repository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        public IEnumerable<Category> GetByEntity(string Entity);

        public List<Category> GetByParentCode(string ParentCode);

        public List<CategoryModelTemplate> GetSavedEntityType();

        public List<Category> GetRecursiveByEntity(string Entity);

        public IEnumerable<CategoryModelTemplate> GetModelTemplateByEntity(string Entity);

        public List<CategoryModelTemplate> GetModelTemplateByEntityAndParentCode(string Entity, string ParentCode);

        public bool IsExistEntityWithCode(string entity, string code, out Category category);
    }
}
