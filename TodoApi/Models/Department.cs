using System;
using TodoApi.Core.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApi.Models {
    [Table("Departments")]
    public partial class Department : AuditBase<short> {
        public Department() {
            Users = new HashSet<User>();
        }

        public string DepartmentName { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
