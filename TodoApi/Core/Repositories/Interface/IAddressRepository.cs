using System;
using System.Linq;
using TodoApi.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TodoApi.Core.Repositories.Interface {
    public interface IAddressRepository {
        Task<Address> GetById(Guid id);
        Task<Address> Create(Address value);
        Task<Address> Delete(Address value);
        Task<IEnumerable<Address>> GetTaskList();
        Task<Address> Update(Guid id, Address value);
    }
}
