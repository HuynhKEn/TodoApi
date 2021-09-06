using System;
using TodoApi.Core.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApi.Models {
    [Table("Salaries")]
    public partial class Salary : AuditBase<Guid> {
        public Salary() {

        }
        public Guid UserId { get; set; }
        public float CoefficientsSalary { get; set; }
        public float WorkDays { get; set; }
        public decimal TotalSalary { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }
    }
}
