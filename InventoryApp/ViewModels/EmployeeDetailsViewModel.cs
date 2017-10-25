using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InventoryApp.Models;

namespace InventoryApp.ViewModels
{
    public class EmployeeDetailsViewModel
    {

        // this will hold one store
        public Store Store {get;set;}

        //this will hold many inventory items in the store
        public List<Inventory> Inventories { get; set; }


    }
}