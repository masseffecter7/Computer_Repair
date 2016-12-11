using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Computer_Repair.Models;
using PagedList;
using PagedList.Mvc;

namespace Computer_Repair.Controllers
{
    public class WorkersController : Controller
    {
        private Computer_RepairContext db = new Computer_RepairContext();

        // GET: Workers
        [Authorize]
        public ActionResult Index(int? page, string currentFilter, string WorkerFind = "")
        {
            if (WorkerFind == "")
            {
                WorkerFind = currentFilter;
            }
            else
            {
                page = 1;
            }
            ViewBag.CurrentFilter = WorkerFind;

            if (WorkerFind != null)
            {
                var workers = from m in db.Workers
                              where m.Surname.StartsWith(WorkerFind)
                              select m;
                return View(workers.ToList().ToPagedList(page ?? 1, 20));
            }
            else
            {
                var workers = from m in db.Workers
                              select m;
                return View(workers.ToList().ToPagedList(page ?? 1, 20));
            }
            
        }

        // GET: Workers/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workers workers = db.Workers.Find(id);
            if (workers == null)
            {
                return HttpNotFound();
            }
            return View(workers);
        }

        // GET: Workers/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Workers/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WorkerId,Name,Surname")] Workers workers)
        {
            if (ModelState.IsValid)
            {
                db.Workers.Add(workers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(workers);
        }

        // GET: Workers/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workers workers = db.Workers.Find(id);
            if (workers == null)
            {
                return HttpNotFound();
            }
            return View(workers);
        }

        // POST: Workers/Edit/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WorkerId,Name,Surname")] Workers workers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(workers);
        }

        // GET: Workers/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workers workers = db.Workers.Find(id);
            if (workers == null)
            {
                return HttpNotFound();
            }
            return View(workers);
        }

        // POST: Workers/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Workers workers = db.Workers.Find(id);
            db.Workers.Remove(workers);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [Authorize]
        public ActionResult Busy(int? page)
        {
            var busy = (from m in db.Workers
                       join n in db.Orders
                       on m.WorkerId equals n.WorkerId
                       where (n.Completed == false)
                       select m).Distinct();
            return View(busy.ToList().ToPagedList(page ?? 1, 20));
        }
    }
}
