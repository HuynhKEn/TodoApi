using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using TodoApi.Core.Repositories.Interface;
using TodoApi.Core.Factory.RelateToUnitOfWork;
using TodoApi.Core.Repositories.InterfaceCommon;


namespace TodoApi.Core.Repositories.ClassCommon {
    public class UnitOfWorkCommit : IUnitOfWorkCommit {
        private UnitOfWorkFactory _dbFactory;

        public UnitOfWorkCommit(UnitOfWorkFactory dbFactory) {
            _dbFactory = dbFactory;
        }

        public Task<int> CommitAsync() {
            return _dbFactory.DbContext.SaveChangesAsync();
        }
    }
}
