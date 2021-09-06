using System;
using TodoApi.Core.Service;
using TodoApi.Core.Context;
using Microsoft.EntityFrameworkCore;
using TodoApi.Core.Repositories.Class;
using Microsoft.Extensions.Configuration;
using TodoApi.Core.Repositories.Interface;
using TodoApi.Core.Repositories.ClassCommon;
using TodoApi.Core.Factory.RelateToUnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using TodoApi.Core.Repositories.InterfaceCommon;

namespace TodoApi.Core.Extensions {
    public static class IServiceCollectionExtensions {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration) {
            // Configure DbContext with Scoped lifetime
            services.AddDbContext<UnitOfWorkContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
    
            }
            );

            services.AddScoped<Func<UnitOfWorkContext>>((provider) => () => provider.GetService<UnitOfWorkContext>());
            services.AddScoped<UnitOfWorkFactory>();
            services.AddScoped<IUnitOfWorkCommit, UnitOfWorkCommit>();

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services) {
            return services
                .AddScoped(typeof(IUnitOfWorkRepository<>), typeof(UnitOfWorkRepository<>))
                .AddScoped<IDepartmentRepository, DepartmentRepository>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<ISalaryRepository, SalaryRepository>();
        }

        public static IServiceCollection AddServices(this IServiceCollection services) {
            return services
                .AddScoped<DepartmentService>();
        }
    }
}
