using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Design;

namespace TodoApi.Core.Factory {
    public class ProjectContextFactory<T> : IDesignTimeDbContextFactory<T> where T : DbContext {

        public T CreateDbContext() {
            return CreateDbContext(null);
        }

        public T CreateDbContext(string[] args) {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            var builder = new DbContextOptionsBuilder<T>();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseSqlServer(connectionString);

            var dbContext = (T)Activator.CreateInstance(
                typeof(T),
                builder.Options);

            return dbContext;
        }
    }
}
