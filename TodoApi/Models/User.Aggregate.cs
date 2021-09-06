using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models {
    public partial class User {
        public bool ValidOnAdd() {
            return
                // Validate userName
                !string.IsNullOrEmpty(UserName)
                // Make sure email not null and correct email format
                && !string.IsNullOrEmpty(Email)
                && new EmailAddressAttribute().IsValid(Email)
                // Make sure department not null
                && (Department != null|| DepartmentId != 0);
        }
    }
}
