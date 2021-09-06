using TodoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace TodoApi.Core.Context {
    public class UnitOfWorkContext : DbContext {
        public DbSet<User> Users { get; set; }
        public DbSet<Salary> Salaries { get; set; }
        public DbSet<Department> Departments { get; set; }
        public UnitOfWorkContext(DbContextOptions<UnitOfWorkContext> options) : base(options) {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
        }

    }
}
