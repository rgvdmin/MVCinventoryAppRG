﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InventoryApp.Data;
using InventoryApp.Models;

namespace InventoryApp.Controllers
{
    public class InventoriesController : Controller
    {
        private InventoryContext db = new InventoryContext();

        // GET: Inventories
        public ActionResult Index(int? storeId)
        {
            if (storeId > 0)
            { 
                
                //if theres a store id provided , then we can use it to filter out the inventory list.

                ViewBag.StoreId = storeId;  //We need to hold the storeId
                                            //return View(db.Inventories.Where(x => x.IsActive == storeId).ToList());

                return View(db.Inventories.Where(x => x.Stores.ID == storeId).ToList());
            }
            else
            {
                return View(db.Inventories.ToList());
            }
        }

        // GET: Inventories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = db.Inventories.Find(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }



        // GET: Inventories/Create
        public ActionResult Create(int? storeId)
        {
            if (storeId > 0)
            {
                var store = (int)storeId;

                Inventory model = new Inventory();
                model.Stores = new Store();
                model.Stores.ID = store;
                model.Stores.Name = db.Stores.Where(x => x.ID == store).FirstOrDefault().Name;
                return View(model);
            } else
            {
                return RedirectToAction("Index", "Stores");
            }
        }

        // POST: Inventories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,PictureUrl,Description,Sku,Qty,Stores,Price,IsActive,Manufacture,Rating")] Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //Assign the store information to the inventory object
                    inventory.Stores = db.Stores.Where(x => x.ID == inventory.Stores.ID).FirstOrDefault();

                    db.Inventories.Add(inventory);
                    db.SaveChanges();


                    return this.Json(new
                    {
                        EnableSuccess = true,
                        SuccessTitle = "Success",
                        SuccessMsg = "Success"
                    });

                    //return RedirectToAction("Index", new { storeId = inventory.Stores.Id });
                }
                catch
                {
                    return this.Json(new
                    {
                        EnableError = true,
                        ErrorTitle = "Error",
                        ErrorMsg = "Something goes wrong, please try again later"
                    });
                }
            }

            return View(inventory);
        }

        // GET: Inventories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = db.Inventories.Find(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }

        // POST: Inventories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,PictureUrl,Description,Sku,Qty,Stores,Price,IsActive,Manufacture,Rating")] Inventory inventory)
        {
            //Creating a second connection to eliminate any collision with the first database connection
            var store = 0;
            using (InventoryContext context = new InventoryContext()) {
                store = context.Inventories.Where(x => x.ID == inventory.ID).FirstOrDefault().Stores.ID;
                context.Dispose();//forces new connection to close
            }
            if (ModelState.IsValid)
            {
                db.Entry(inventory).State = EntityState.Modified;
                db.SaveChanges();
                //return RedirectToAction("Index");
            }

            return RedirectToAction("Index", new { storeId = store });
        }

        // GET: Inventories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = db.Inventories.Find(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }

        // POST: Inventories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inventory inventory = db.Inventories.Find(id);
            db.Inventories.Remove(inventory);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ViewInventories(int storeId)
        {

            ViewBag.StoreId = storeId;
            ViewBag.StoreName = db.Stores.Where(x => x.ID == storeId).FirstOrDefault().Name;
            
            return View(db.Inventories.Where(x => x.Stores.ID == storeId).ToList());
            
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
