using System;
using System.Linq;
using TodoApi.Models;
using Newtonsoft.Json;
using TodoApi.Core.Utils;
using TodoApi.Models.Request;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;
using TodoApi.Core.Repositories.Interface;
using TodoApi.Core.Repositories.ClassCommon;
using TodoApi.Core.Factory.RelateToUnitOfWork;

namespace TodoApi.Core.Repositories.Class {
    public class UserRepository : UnitOfWorkRepository<User>, IUserRepository {
        public UserRepository(UnitOfWorkFactory dbFactory) : base(dbFactory) {
        }

        public User NewUser(User user) {
                if (user.ValidOnAdd()) {
                    this.Add(user);
                    return user;
                } else
                    throw new Exception("User invalid");
        }
        
        public IEnumerable<User> GetById(Guid id) {
            return this.List(x => x.Id == id).Take(1);
        }

        public User AuthenticateUser(AuthenticateRequest user) {
            return this.List(x => x.UserName == user.UserName && x.Password == user.Password)
                .OrderBy(x => x.Id).Take(1).FirstOrDefault();
        }
    }
}
