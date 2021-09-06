using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;


namespace TodoApi.Core.Repositories.InterfaceCommon {
    public interface IUnitOfWorkRepository<T> where T : class {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        IQueryable<T> List(Expression<Func<T, bool>> expression);
    }
}
