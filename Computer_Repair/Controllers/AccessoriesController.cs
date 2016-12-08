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
    public class AccessoriesController : Controller
    {
        private Computer_RepairContext db = new Computer_RepairContext();

        // GET: Accessories
        public ActionResult Index(int? page, string currentFilter, string AccessorieFind = "")
        {
            if (AccessorieFind == "")
            {
                AccessorieFind = currentFilter;
            }
            else
            {
                page = 1;
            }
            ViewBag.CurrentFilter = AccessorieFind;

            if (AccessorieFind != null)
            {
                var accessories = from m in db.Accessories.Include(a => a.KindsOfAccessories)
                                  where m.AccessorieName.StartsWith(AccessorieFind)
                                  select m;
                return View(accessories.ToList().ToPagedList(page ?? 1, 20));
            }
            else
            {
                var accessories = from m in db.Accessories.Include(a => a.KindsOfAccessories)
                                  select m;
                return View(accessories.ToList().ToPagedList(page ?? 1, 20));
            }
        }

        // GET: Accessories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accessories accessories = db.Accessories.Find(id);
            if (accessories == null)
            {
                return HttpNotFound();
            }
            return View(accessories);
        }

        // GET: Accessories/Create
        public ActionResult Create()
        {
            ViewBag.KindId = new SelectList(db.KindsOfAccessories, "KindId", "Kind");
            return View();
        }

        // POST: Accessories/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AccessorieId,KindId,AccessorieName,Firm,Country,ReleaseDate,Characteristics,Description,Price")] Accessories accessories)
        {
            if (ModelState.IsValid)
            {
                db.Accessories.Add(accessories);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KindId = new SelectList(db.KindsOfAccessories, "KindId", "Kind", accessories.KindId);
            return View(accessories);
        }

        // GET: Accessories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accessories accessories = db.Accessories.Find(id);
            if (accessories == null)
            {
                return HttpNotFound();
            }
            ViewBag.KindId = new SelectList(db.KindsOfAccessories, "KindId", "Kind", accessories.KindId);
            return View(accessories);
        }

        // POST: Accessories/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AccessorieId,KindId,AccessorieName,Firm,Country,ReleaseDate,Characteristics,Description,Price")] Accessories accessories)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accessories).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KindId = new SelectList(db.KindsOfAccessories, "KindId", "Kind", accessories.KindId);
            return View(accessories);
        }

        // GET: Accessories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accessories accessories = db.Accessories.Find(id);
            if (accessories == null)
            {
                return HttpNotFound();
            }
            return View(accessories);
        }

        // POST: Accessories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Accessories accessories = db.Accessories.Find(id);
            db.Accessories.Remove(accessories);
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
