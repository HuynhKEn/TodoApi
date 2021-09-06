using System;
using TodoApi.Models;

namespace TodoApi.Core.Utils.Interface {
    public interface IJwtUtils {
        public string GenerateJwtToken(User user);
        public Guid? ValidateToken(string token);
    }
}
