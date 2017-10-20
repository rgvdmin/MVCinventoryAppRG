using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace InventoryApp.ViewModels
{
    public class EmployeesViewModel
    {
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Emp Id")]
        public int EmployeeId { get; set; }

        [DisplayName("Active")]
        public bool IsActive { get; set; }

        [DisplayName("Role")]
        public int Role { get; set; }


    }
}