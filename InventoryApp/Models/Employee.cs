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
       public string FirstName { get; set; }
       public string LastName { get; set; }
       public int EmployeeID { get; set; }
       public bool IsActive { get; set; }
       
       [DisplayName("Role")] 
       public int LK_EmployeeTypesID { get; set; }

       [ForeignKey("LK_EmployeeTypesID")]
       [DisplayName("Role")]
       public virtual LK_EmployeeTypes Lk_EmployeeTypes { get; set; }

        public int StoreId { get; set; }
        [ForeignKey("StoreId")]
        public virtual Store Store { get; set; }

    }
}