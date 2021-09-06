using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models.Response {
    public class AuthenticateResponse {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
        public Role Role { get; set; }

        public AuthenticateResponse(User user, string token) {
            Id = user.Id;
            Token = token;
            UserName = user.UserName;
            Role = user.Role;
        }
    }
}
