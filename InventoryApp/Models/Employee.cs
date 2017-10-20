using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InventoryApp.Models
{
    public class Employee
    {
       public int ID { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Emp ID")]
        public int EmployeeID { get; set; }

        [DisplayName("Active")]
        public bool IsActive { get; set; }
       
       [DisplayName("Role")] 
       public int LK_EmployeeTypesID { get; set; }

       [ForeignKey("LK_EmployeeTypesID")]
       public virtual LK_EmployeeTypes Lk_EmployeeTypes { get; set; }

        [DisplayName("Store Name")]
        // this is the name of the Var that will hold the value from Store
        public int StoreId { get; set; }

        // this connects the name of StoreId to call Store object
        [ForeignKey("StoreId")]
        public virtual Store Store { get; set; }

    }
}