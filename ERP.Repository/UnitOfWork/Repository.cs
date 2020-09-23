using ERP.Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ERP.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        internal DbSet<T> dbSet;
        internal SonTungContext context;

        public Repository(SonTungContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public virtual IEnumerable<T> Get(Expression<Func<T, bool>> fillter = null, 
                                          Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                          string includeProperties = "")
        {
            IQueryable<T> query = dbSet;

            if(fillter != null)
            {
                query.Where(fillter);
            }

            foreach (var includeProperty in includeProperties.Split(new char[] { ','}, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if(orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual T GetById(object id)
        {
            return dbSet.Find(id);
        }

        public virtual int Insert(T entity)
        {
            dbSet.Add(entity);
            return context.SaveChanges();
        }

        public virtual int Update(T entity)
        {
            dbSet.Attach(entity);
            return context.SaveChanges();
        }

        public virtual int Delete(object id)
        {
            T entity = dbSet.Find(id);
            return Delete(entity);
        }

        public virtual int Delete(T entity)
        {
            if(context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
            return context.SaveChanges();
        }

        public int SoftDelete(object id)
        {
            T entity = dbSet.Find(id);
            entity.GetType().GetProperty("Deleted")?.SetValue(entity, false);
            return Update(entity);
        }
    }
}
