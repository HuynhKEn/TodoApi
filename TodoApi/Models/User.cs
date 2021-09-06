using System;
using TodoApi.Core.Base;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApi.Models {
    [Table("Users")]
    public partial class User : AuditBase<Guid> {
        public User() {
            Salaries = new HashSet<Salary>();
        }

        public string UserName { get; set; }

        [EmailAddress]
        public string Email { get; set; }


        [JsonIgnore]
        public string Password { get; set; }
         
        public Role Role { get; set; }


        public short DepartmentId { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        public virtual Department Department { get; set; }

        public virtual ICollection<Salary> Salaries { get; set; }
    }
}
