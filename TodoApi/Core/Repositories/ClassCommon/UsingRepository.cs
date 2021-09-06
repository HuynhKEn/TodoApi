using System;
using TodoApi.Models;
using TodoApi.Core.Factory;
using TodoApi.Core.Context;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TodoApi.Core.Repositories.Interface;

namespace TodoApi.Core.Repositories.ClassCommon {
    public class UsingRepository : IAddressRepository {
        private ProjectContextFactory<UsingContext> _contextTodo;
        public UsingRepository(ProjectContextFactory<UsingContext> contextTodo) {
            _contextTodo = contextTodo;
        }
        public async Task<IEnumerable<Address>> GetTaskList() {
            using (var _context = _contextTodo.CreateDbContext()) {
                return await _context.Address.ToListAsync();
            }
        }
        public async Task<Address> GetById(Guid id) {
            using (var _context = _contextTodo.CreateDbContext()) {
                var result = await _context.Address.FindAsync(id);
                return result;
            }
        }
        public async Task<Address> Create(Address value) {
            using (var _context = _contextTodo.CreateDbContext()) {
                await _context.Address.AddAsync(value);
                await _context.SaveChangesAsync();
                return value;
            }
        }
        public async Task<Address> Update(Guid id, Address value) {
            using (var _context = _contextTodo.CreateDbContext()) {
                _context.Address.Update(value);
                await _context.SaveChangesAsync();
                return value;
            }
        }

        public async Task<Address> Delete(Address value) {
            using(var _context = _contextTodo.CreateDbContext()) {
                _context.Address.Remove(value);
                await _context.SaveChangesAsync();
                return value;
            }
        }

    }
}
