using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models {
    public partial class Department
    {
        public Department(string departmentName) : base()
        {
            this.DepartmentName = departmentName;
        }

        public bool ValidOnAdd()
        {
            return !string.IsNullOrEmpty(DepartmentName);
        }
    }
}
