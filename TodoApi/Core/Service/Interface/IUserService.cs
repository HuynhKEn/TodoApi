using System;
using System.Linq;
using TodoApi.Models;
using System.Threading.Tasks;
using TodoApi.Models.Request;
using TodoApi.Models.Response;
using System.Collections.Generic;

namespace TodoApi.Core.Service.Interface {
    public interface IUserService {

        public User GetById(Guid id);

        public AuthenticateResponse Authenticate(AuthenticateRequest user);
    }
}
