using System;
using TodoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace TodoApi.Core.Context {
    public class UsingContext : DbContext {
        public DbSet<Address> Address { get; set; }
        public UsingContext(DbContextOptions<UsingContext> options) : base(options) {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
        }

    }
}
