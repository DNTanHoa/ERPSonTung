﻿using ERP.Model.DataTransferObjects;
using ERP.Model.Models;
using ERP.Ultilities.Extensions;
using ERP.Ultilities.Global;
using ERP.Ultilities.Helpers;
using System.Data.SqlClient;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Data;
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

        public List<Category> GetRecursiveByEntity(string Entity)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@Entity",Entity)
            };
            DataTable table = SqlHelper.Fill(AppGlobal.ConnectionString, "sprocCategorySelectRecursiveByEntity", parameters);
            return table.ToList<Category>();
        }

        public IEnumerable<CategoryModelTemplate> GetModelTemplateByEntity(string Entity)
        {
            return context.Category.Where(item => item.Entity.Equals(Entity)).Select(item => new CategoryModelTemplate { Code = item.Code, Display = item.Code + " - " + item.Name });
        }

        public List<CategoryModelTemplate> GetSavedEntityType()
        {
            return context.Category.Select(item => new CategoryModelTemplate { Code = item.Entity, Display = item.Note }).Distinct().ToList();
        }

        public List<CategoryModelTemplate> GetModelTemplateByEntityAndParentCode(string Entity, string ParentCode)
        {
            return context.Category.Where(item => item.Entity.Equals(Entity)
                                               && (item.ParentCode.Equals(ParentCode) || ParentCode.Equals(string.Empty))).Select(item => new CategoryModelTemplate { Code = item.Code, Display = item.Note + " " + item.Name }).ToList();
        }

        public List<Category> GetByParentCode(string ParentCode)
        {
            return context.Category.Where(item => item.ParentCode.Equals(ParentCode)).ToList();
        }
    }
}
