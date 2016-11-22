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
        [Authorize]
        public ActionResult Index(int page = 1, string AccessorieFind = "")
        {
            var accessories = from m in db.Accessories.Include(a => a.KindsOfAccessories)
                          where m.AccessorieName.StartsWith(AccessorieFind)
                          select m;
            return View(accessories.ToList().ToPagedList(page, 20));
        }

        // GET: Accessories/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accessorie accessorie = db.Accessories.Find(id);
            if (accessorie == null)
            {
                return HttpNotFound();
            }
            return View(accessorie);
        }

        // GET: Accessories/Create
        [Authorize (Roles="admin")]
        public ActionResult Create()
        {
            ViewBag.KindId = new SelectList(db.KindsOfAccessories, "KindId", "Kind");
            return View();
        }

        // POST: Accessories/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AccessorieId,KindId,AccessorieName,Description,Price")] Accessorie accessorie)
        {
            if (ModelState.IsValid)
            {
                db.Accessories.Add(accessorie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KindId = new SelectList(db.KindsOfAccessories, "KindId", "Kind", accessorie.KindId);
            return View(accessorie);
        }

        // GET: Accessories/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accessorie accessorie = db.Accessories.Find(id);
            if (accessorie == null)
            {
                return HttpNotFound();
            }
            ViewBag.KindId = new SelectList(db.KindsOfAccessories, "KindId", "Kind", accessorie.KindId);
            return View(accessorie);
        }

        // POST: Accessories/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AccessorieId,KindId,AccessorieName,Description,Price")] Accessorie accessorie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accessorie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KindId = new SelectList(db.KindsOfAccessories, "KindId", "Kind", accessorie.KindId);
            return View(accessorie);
        }

        // GET: Accessories/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accessorie accessorie = db.Accessories.Find(id);
            if (accessorie == null)
            {
                return HttpNotFound();
            }
            return View(accessorie);
        }

        // POST: Accessories/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Accessorie accessorie = db.Accessories.Find(id);
            db.Accessories.Remove(accessorie);
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
