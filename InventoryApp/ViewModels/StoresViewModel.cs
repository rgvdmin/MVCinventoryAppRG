using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace InventoryApp.ViewModels
{
    public class StoresViewModel
    {

        public string Name { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        [DisplayName("Active")]
        public bool IsActive { get; set; }

        [DisplayName("Manager Name")]
        public string ManagerName { get; set; }


    }
}
