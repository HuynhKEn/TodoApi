using System;
using System.Linq;
using TodoApi.Core.Context;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TodoApi.Core.Factory.RelateToUnitOfWork {
    public class UnitOfWorkFactory : IDisposable {
        private bool _disposed;
        private DbContext _dbContext;
        private Func<UnitOfWorkContext> _instanceFunc;
        public DbContext DbContext => _dbContext ?? (_dbContext = _instanceFunc.Invoke());

        public UnitOfWorkFactory(Func<UnitOfWorkContext> dbContextFactory) {
            _instanceFunc = dbContextFactory;
        }

        public void Dispose() {
            if (!_disposed && _dbContext != null) {
                _disposed = true;
                _dbContext.Dispose();
            }
        }
    }
}
