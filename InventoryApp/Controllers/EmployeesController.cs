using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InventoryApp.Data;
using InventoryApp.Models;
using System.Threading.Tasks;
using Syncfusion.JavaScript.DataSources;
using System.Collections;
using Syncfusion.Linq;
using Syncfusion.JavaScript;

namespace InventoryApp.Controllers
{
    public class EmployeesController : Controller
    {
        private InventoryContext db = new InventoryContext();

        // GET: Employees
        public ActionResult Index()
        {


            ViewBag.dataSourcePosition = (from employeeTypes in db.LK_EmployeeTypes
                                          select new
                                          {
                                              text = employeeTypes.Name,
                                              value = employeeTypes.Name
                                          }).ToList();


            
            ViewBag.dataSourceStore = (from Store in db.Stores
                                          select new
                                          {
                                              text = Store.Name,
                                              value = Store.Name
                                          }).ToList();



            return View(db.Employees.ToList());
        }

        public ActionResult InlineEdit(Employee value)
        {


            Store store = new Store();
            store = db.Stores.Where(x => x.Name == value.Store.Name).FirstOrDefault();

            //lets assign the an instance of the class(object) positions
            // to hold our value

            value.Store = store;
            value.StoreId = store.ID;

            LK_EmployeeTypes employeeTypes = new LK_EmployeeTypes();
            employeeTypes = db.LK_EmployeeTypes.Where(x => x.Name == value.Lk_EmployeeTypes.Name).FirstOrDefault();

            //lets assign the an instance of the class(object) positions
            // to hold our value

            value.Lk_EmployeeTypes = employeeTypes;
            value.LK_EmployeeTypesID = employeeTypes.ID;

            db.Entry(value).State = EntityState.Modified;
            db.SaveChanges();

            return Json(value, JsonRequestBehavior.AllowGet);
        
        }
        public ActionResult InlineRemove(int key)
        {
            Employee employee = new Employee();

            employee = db.Employees.Where(x => x.ID == key).FirstOrDefault();

            db.Entry(employee).State = EntityState.Deleted;
            db.SaveChanges();

            return Json(key, JsonRequestBehavior.AllowGet);
        }

        public ActionResult InlineInsert(Employee value)
        {
            db.Entry(value).State = EntityState.Added;
            db.SaveChanges();

            return Json(value, JsonRequestBehavior.AllowGet);

        }


        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            //Create a dropdown list
            ViewBag.LK_EmployeeTypes = db.LK_EmployeeTypes.ToList();
            ViewBag.Store = db.Stores.ToList();

            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,EmployeeID,LK_EmployeeTypesID,IsActive,StoreId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            //Create a dropdown list
            ViewBag.LK_EmployeeTypes = db.LK_EmployeeTypes.ToList();
            ViewBag.Store = db.Stores.ToList();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,EmployeeID,LK_EmployeeTypesID,IsActive,StoreId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ViewEmployees(int storeId)
        {
            var model = db.Employees.Where(x => x.Store.ID == storeId).ToList();
            return View("Index",model);
        }

        [HttpGet]
        public async Task<ActionResult> GetPartialView(int Id)
        {
            var model = db.Employees.Where(x => x.StoreId == Id).ToList(); //Find all employees for a store

            if (model.Count > 0)
            {
                return PartialView("_EmployeeList", model);
            }

            return PartialView("_NoResultsFound");
        }


        public class DataResult
        {

            public IEnumerable result { get; set; }
            public int count { get; set; }

        }

        public ActionResult InlineDataSource(DataManager dataManager)
        {

            // Get the datasource
            IEnumerable Datasource = db.Employees;

            //IEnumerable Datasource = from Employees in db.Employees
            //                         join Stores in db.Stores on Employees.StoreId equals Stores.ID
            //                         select new
            //                         {
            //                             Store.
            //                         };

            //Create the Object
            DataResult result = new DataResult();
            DataOperations operation = new DataOperations();

            //Populate the objects
            result.result = Datasource;
            result.count = result.result.AsQueryable().Count();

            //Createing conditions to check if we are going to skip any records
            if(dataManager.Skip > 0)
            {
                result.result = operation.PerformSkip(result.result, dataManager.Skip);
            }

            //Check if the user will be taking/removing any objects
            if(dataManager.Take > 0)
            {
                result.result = operation.PerformTake(result.result, dataManager.Take);
            }
            return Json(result, JsonRequestBehavior.AllowGet);

        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


    }
}
