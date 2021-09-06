using System;
using TodoApi.Models;
using TodoApi.Models.Request;
using System.Collections.Generic;
using TodoApi.Core.Repositories.InterfaceCommon;

namespace TodoApi.Core.Repositories.Interface {
    public interface IUserRepository : IUnitOfWorkRepository<User> {
        User NewUser(User user);
        IEnumerable<User> GetById(Guid id);

        User AuthenticateUser(AuthenticateRequest user);
    }
}
