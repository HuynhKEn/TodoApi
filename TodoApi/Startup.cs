using TodoApi.Core;
using TodoApi.Core.Factory;
using TodoApi.Core.Helpers;
using TodoApi.Core.Service;
using TodoApi.Core.Middleware;
using TodoApi.Core.Extensions;
using Microsoft.OpenApi.Models;
using TodoApi.Core.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TodoApi.Core.Service.Interface;
using Microsoft.Extensions.Configuration;
using TodoApi.Core.Repositories.Interface;
using TodoApi.Core.Repositories.ClassCommon;
using Microsoft.Extensions.DependencyInjection;


namespace TodoApi {
    public class Startup {

        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

            /* services.AddTransient<IAddressRepository, FactoryRepository>(); */
            /* services.AddScoped(typeof(ProjectContextFactory<>), typeof(ProjectContextFactory<>)); */

            services.AddDatabase(Configuration)
                .AddRepositories()
                .AddServices();

            services.AddJwtAuth()
                .AddUtilsJwtAuth();

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env,
            IHostApplicationLifetime applicationLifetime,
            Microsoft.AspNetCore.Mvc.Infrastructure.IActionDescriptorCollectionProvider _actionDescriptorCollectionProvider,
            ILogger<Startup> logger
            ) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                ShowRouter.ShowInfo(_actionDescriptorCollectionProvider, applicationLifetime, logger);
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(x => x
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());

            app.UseMiddleware<JwtMiddleware>();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
