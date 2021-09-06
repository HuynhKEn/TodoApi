using TodoApi.Models;
using TodoApi.Core.Repositories.InterfaceCommon;

namespace TodoApi.Core.Repositories.Interface {
    public interface IDepartmentRepository : IUnitOfWorkRepository<Department> {
        Department AddDepartment(string departmentName);
    }
}
