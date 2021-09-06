using System;
using System.Linq;
using TodoApi.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using TodoApi.Core.Repositories.Interface;
using TodoApi.Core.Repositories.ClassCommon;
using TodoApi.Core.Factory.RelateToUnitOfWork;

namespace TodoApi.Core.Repositories.Class {
    public class SalaryRepository : UnitOfWorkRepository<Salary>, ISalaryRepository {
        public SalaryRepository(UnitOfWorkFactory dbFactory) : base(dbFactory) {
        }

        public Salary AddUserSalary(User user, float coefficientsSalary, float workdays) {
            var salary = new Salary(user, coefficientsSalary, workdays);
            if (salary.ValidOnAdd()) {
                this.Add(salary);
                return salary;
            } else
                throw new Exception("Salary invalid");
        }
    }
}
