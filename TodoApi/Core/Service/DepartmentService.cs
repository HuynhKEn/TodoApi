using System;
using System.Linq;
using TodoApi.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using TodoApi.Core.Repositories.Interface;
using TodoApi.Core.Repositories.InterfaceCommon;

namespace TodoApi.Core.Service {
    public class DepartmentService {
        private readonly IUnitOfWorkCommit _unitOfWork;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IUserRepository _userRepository;
        private readonly ISalaryRepository _salaryRepository;

        public DepartmentService(IUnitOfWorkCommit unitOfWork
            , IDepartmentRepository departmentRepository
            , IUserRepository userRepository
            , ISalaryRepository salaryRepository) {
            _unitOfWork = unitOfWork;
            _departmentRepository = departmentRepository;
            _userRepository = userRepository;
            _salaryRepository = salaryRepository;
        }

        public async Task<bool> AddAllEntitiesAsync() {
            var departMentName = $"department_{Guid.NewGuid():N}";
            var department = _departmentRepository.AddDepartment(departMentName);
            var userName = $"user_{Guid.NewGuid():N}";
            var password = "12345678";
            var userEmail = $"{Guid.NewGuid():N}@gmail.com";
            
            User userInfo = new User() {
                UserName = userName,
                Password = password,
                Email = userEmail,
                Role = Role.Admin
            };
            var user = _userRepository.NewUser(userInfo);

            // create new Salary with above User
            float coefficientsSalary = new Random().Next(1, 15);
            float workdays = 22;
            var salary = _salaryRepository.AddUserSalary(user, coefficientsSalary, workdays);

            // Commit all changes with one single commit
            var saved = await _unitOfWork.CommitAsync();

            return saved > 0;
        }
    }
}
