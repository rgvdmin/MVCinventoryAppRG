using InventoryApp.Data;
using InventoryApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryApp.Controllers
{
    public class StoresViewModelController : Controller
    {

        private InventoryContext db = new InventoryContext();
        // GET: StoresViewModel
        public ActionResult Index()
        {
            return View();

        //    var Results =
        //        (from store in db.Stores
        //         join employee in db.Employees
        //          on store.EmployeeID equals employee.ID
        //         select new StoresViewModel
        //         {
        //             Name = store.Name,
        //             IsActive = store.IsActive,


        //             ManagerName = (employee.FirstName +" "+ employee.LastName),
                  

        //         }).ToList();




        //    return View(Results);
        }
    }
}