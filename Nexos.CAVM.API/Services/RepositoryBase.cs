using Microsoft.EntityFrameworkCore;
using Nexos.CAVM.API.Context;
using Nexos.CAVM.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Nexos.CAVM.API.Services
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : BaseEntity
    {
        protected ProjectContext RepositoryContext { get; set; }
        public RepositoryBase(ProjectContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }
        
        public IQueryable<T> FindAll()
        {
            return RepositoryContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return RepositoryContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            entity.CreatedTime = DateTime.Now;
            entity.LastUpdatedTime = DateTime.Now;
            RepositoryContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            RepositoryContext.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            entity.LastUpdatedTime = DateTime.Now;
            RepositoryContext.Set<T>().Update(entity);
        }
    }
}
