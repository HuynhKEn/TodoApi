using System;
using System.Linq;
using TodoApi.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using TodoApi.Core.Repositories.Interface;
using TodoApi.Core.Factory.RelateToUnitOfWork;
using TodoApi.Core.Repositories.ClassCommon;

namespace TodoApi.Core.Repositories.Class {
    public class DepartmentRepository : UnitOfWorkRepository<Department>, IDepartmentRepository {
        public DepartmentRepository(UnitOfWorkFactory dbFactory) : base(dbFactory) {
        }

        public Department AddDepartment(string departmentName) {
            var department = new Department(departmentName);
            if (department.ValidOnAdd()) {
                this.Add(department);
                return department;
            } else
                throw new Exception("Department invalid");
        }
    }
}
