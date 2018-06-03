using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Neptuno.Data.Pagination;

namespace Neptuno.Data.Repositories
{
    public class RepositoryGeneric<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private readonly IDbContext _dataContext;

        private DbSet<TEntity> Dbset
        {
            get { return _dataContext.GetSet<TEntity>(); }
        }

        public RepositoryGeneric(IDbContext dbContext)
        {
            _dataContext = dbContext;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Dbset.AsEnumerable();
        }

        public TEntity GetById(int id)
        {
            return Dbset.Find(id);
        }
        public int Count(Expression<Func<TEntity, bool>> where)
        {
            return Dbset.Count(where);
        }

        public void Insert(TEntity entity)
        {
            Dbset.Add(entity);
        }

        public void Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            Dbset.Attach(entity);
            _dataContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity == null)
                throw new Exception("entity");
            Dbset.Remove(entity);
        }

        public void Delete(TEntity entity)
        {
            Dbset.Remove(entity);
        }

        public void Delete(Expression<Func<TEntity, bool>> @where)
        {
            IEnumerable<TEntity> objects = Dbset.Where(where).AsEnumerable();
            foreach (TEntity obj in objects)
                Dbset.Remove(obj);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> @where, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeProperties = null)
        {
            IQueryable<TEntity> query = Dbset;

            query = query.Where(where);

            if (includeProperties != null)
            {
                query = includeProperties(query);
            }

            return query.FirstOrDefault();
        }

        public IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> where,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeProperties = null,
            IPaginationModel paging = null)
        {
            IQueryable<TEntity> query = Dbset;

            query = query.Where(where);

            if (includeProperties != null)
            {
                query = includeProperties(query);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (paging != null)
                return query.GetListPage<TEntity>(paging);
            else
                return query.ToList();
        }
    }
}
