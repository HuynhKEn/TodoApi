using System;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using TodoApi.Core.Helpers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using TodoApi.Core.Utils.Interface;
using Microsoft.IdentityModel.Tokens;
using TodoApi.Core.Service.Interface;
using System.IdentityModel.Tokens.Jwt;

namespace TodoApi.Core.Middleware {
    public class JwtMiddleware {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;
        public JwtMiddleware(RequestDelegate next,
            IOptions<AppSettings> appSettings) {
            _next = next;
            _appSettings = appSettings.Value;
        }

        public async Task Invoke(HttpContext context, IUserService userService, IJwtUtils jwtUtils) {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = jwtUtils.ValidateToken(token);
            if (userId != null) {
                // attach user to context on successful jwt validation
                var userInfo = userService.GetById((Guid)userId);
                context.Items["User"] = userInfo;
            }
            await _next(context);
        }

    }
}
