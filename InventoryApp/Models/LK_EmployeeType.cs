using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace InventoryApp.Models
{
    public class LK_EmployeeTypes
    {
        public int ID { get; set; }
        [DisplayName("Role")]
        public string Name { get; set; }
    }
}