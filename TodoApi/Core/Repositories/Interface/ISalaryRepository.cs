using TodoApi.Models;
using TodoApi.Core.Repositories.InterfaceCommon;

namespace TodoApi.Core.Repositories.Interface {
    public interface ISalaryRepository : IUnitOfWorkRepository<Salary> {
        Salary AddUserSalary(User user, float coefficientsSalary, float workdays);
    }
}
