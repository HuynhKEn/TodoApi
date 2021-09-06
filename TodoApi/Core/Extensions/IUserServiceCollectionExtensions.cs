using TodoApi.Core.Utils;
using TodoApi.Core.Service;
using TodoApi.Models.Request;
using TodoApi.Models.Response;
using TodoApi.Core.Utils.Interface;
using TodoApi.Core.Service.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace TodoApi.Core.Extensions {
    public static class IUserServiceCollectionExtensions {

        public static IServiceCollection AddJwtAuth(this IServiceCollection services) {
            return services.AddScoped<IUserService, UserService>();
        }

        public static IServiceCollection AddUtilsJwtAuth(this IServiceCollection services) {
            return services.AddScoped<IJwtUtils, JwtUtils>();
        }
    }
}
