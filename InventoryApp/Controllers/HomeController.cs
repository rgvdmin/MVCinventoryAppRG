using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InventoryApp.Data;
using InventoryApp.Models;
using System.Threading.Tasks;


namespace InventoryApp.Controllers
{
    public class HomeController : Controller
    {

        private InventoryContext db = new InventoryContext();

        public ActionResult Index()
        {


            return View(db.NewsPosts.ToList());

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult CreateNewPost()
        {
          
            ViewBag.News = db.NewsPosts.ToList();

            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateNewPost([Bind(Include = "Id,Title,TimePosted,Content,Url")] News news)
        {
            if (ModelState.IsValid)
            {
                db.NewsPosts.Add(news);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(news);
        }
    }
}