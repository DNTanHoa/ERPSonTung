﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ERP.Repository
{
    public interface IRepository<T> where T : class
    {
        public int Insert(T entity);

        public int Insert(List<T> entityList);

        public int Insert(T entity, out T result);

        public int Update(T entity);

        public int Update(List<T> entityList);

        public int Update(T entity, out T result);

        public int Delete(object id);

        public int Delete(T entity);

        public int Delete(List<T> entityList);

        public int SoftDelete(object id);

        public IEnumerable<T> Get(Expression<Func<T, bool>> fillter = null,
                                          Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                          string includeProperties = "");

        public T GetById(object id);
    }
}
