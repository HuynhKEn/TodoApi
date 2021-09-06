using System;
using System.Linq;
using TodoApi.Core.Base;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TodoApi.Core.Factory.RelateToUnitOfWork;
using TodoApi.Core.Repositories.InterfaceCommon;

namespace TodoApi.Core.Repositories.ClassCommon {
    public class UnitOfWorkRepository<T> : IUnitOfWorkRepository<T> where T : class {
        private readonly UnitOfWorkFactory _dbFactory;
        private DbSet<T> _dbSet;

        protected DbSet<T> DbSet {
            get => _dbSet ?? (_dbSet = _dbFactory.DbContext.Set<T>());
        }

        public UnitOfWorkRepository(UnitOfWorkFactory dbFactory) {
            _dbFactory = dbFactory;
        }

        public void Add(T entity) {
            if (typeof(IAuditBase).IsAssignableFrom(typeof(T))) {
                ((IAuditBase)entity).CreatedDate = DateTime.UtcNow;
            }
            DbSet.Add(entity);
        }

        public void Delete(T entity) {
            if (typeof(IDeleteBase).IsAssignableFrom(typeof(T))) {
                ((IDeleteBase)entity).IsDeleted = true;
                DbSet.Update(entity);
            } else
                DbSet.Remove(entity);
        }

        public IQueryable<T> List(Expression<Func<T, bool>> expression) {
            return DbSet.Where(expression);
        }

        public void Update(T entity) {
            if (typeof(IAuditBase).IsAssignableFrom(typeof(T))) {
                ((IAuditBase)entity).UpdatedDate = DateTime.UtcNow;
            }
            DbSet.Update(entity);
        }
    }
}
