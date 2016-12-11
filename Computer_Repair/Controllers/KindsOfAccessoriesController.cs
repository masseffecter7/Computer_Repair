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
    public class KindsOfAccessoriesController : Controller
    {
        private Computer_RepairContext db = new Computer_RepairContext();

        // GET: KindsOfAccessories
        [Authorize]
        public ActionResult Index(int? page, string currentFilter, string KindFind = "")
        {
            if (KindFind == "")
            {
                KindFind = currentFilter;
            }
            else
            {
                page = 1;
            }
            ViewBag.CurrentFilter = KindFind;

            if (KindFind != null)
            {
                var kinds = from m in db.KindsOfAccessories
                            where m.Kind.StartsWith(KindFind)
                            select m;
                return View(kinds.ToList().ToPagedList(page ?? 1, 20));
            }
            else
            {
                var kinds = from m in db.KindsOfAccessories
                            select m;
                return View(kinds.ToList().ToPagedList(page ?? 1, 20));
            }
            
        }

        // GET: KindsOfAccessories/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KindsOfAccessories kindsOfAccessories = db.KindsOfAccessories.Find(id);
            if (kindsOfAccessories == null)
            {
                return HttpNotFound();
            }
            return View(kindsOfAccessories);
        }

        // GET: KindsOfAccessories/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: KindsOfAccessories/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KindId,Kind,Description")] KindsOfAccessories kindsOfAccessories)
        {
            if (ModelState.IsValid)
            {
                db.KindsOfAccessories.Add(kindsOfAccessories);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kindsOfAccessories);
        }

        // GET: KindsOfAccessories/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KindsOfAccessories kindsOfAccessories = db.KindsOfAccessories.Find(id);
            if (kindsOfAccessories == null)
            {
                return HttpNotFound();
            }
            return View(kindsOfAccessories);
        }

        // POST: KindsOfAccessories/Edit/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KindId,Kind,Description")] KindsOfAccessories kindsOfAccessories)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(kindsOfAccessories).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch { }
            }
            return View(kindsOfAccessories);
        }

        // GET: KindsOfAccessories/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KindsOfAccessories kindsOfAccessories = db.KindsOfAccessories.Find(id);
            if (kindsOfAccessories == null)
            {
                return HttpNotFound();
            }
            return View(kindsOfAccessories);
        }

        // POST: KindsOfAccessories/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KindsOfAccessories kindsOfAccessories = db.KindsOfAccessories.Find(id);
            db.KindsOfAccessories.Remove(kindsOfAccessories);
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
    }
}
